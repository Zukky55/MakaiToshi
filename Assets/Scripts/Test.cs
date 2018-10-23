
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DemonicCity.BattleScene
{

    public class Test : MonoBehaviour
    {

        //[ContextMenu("Run")]
        private void Start()
        {
            DetectFromPercent();
            DetermineFromDict();
        }

        //確率判定のテスト
        private void DetectFromPercent()
        {

            int trueCount = 0;
            int calcCount = 1000000;
            float per = 0.2f;

            for (int i = 0; i < calcCount; i++)
            {
                if (ProbabilityCalcurator.DetectFromPercent(per))
                    trueCount++;
            }

            Debug.Log("真偽判定の精度確認\n試行回数 : " + calcCount + "回, 目標 : " + per + "%, 実際 : " + ((float)trueCount / (float)calcCount * 100f) + "%");

        }

        //一個選ぶテスト
        private void DetermineFromDict()
        {

            Dictionary<Color, int> targetDict = new Dictionary<Color, int>() {
      {Color.red, 25}, {Color.green, 15}, {Color.blue, 60}
    };
            Dictionary<Color, int> trueCountDict = new Dictionary<Color, int>() {
      {Color.red, 0}, {Color.green, 0}, {Color.blue, 0}
    };

            int calcCount = 1000000;

            for (int i = 0; i < calcCount; i++)
            {
                trueCountDict[ProbabilityCalcurator.DetermineFromDict<Color>(targetDict)]++;
            }

            string logText = "抽選の精度確認\n試行回数 : " + calcCount.ToString() + "回\n";

            foreach (KeyValuePair<Color, int> pair in targetDict)
            {
                logText += pair.Key.ToString() + " 目標 : " + pair.Value.ToString() + "%, 実際 : "
                  + ((float)trueCountDict[pair.Key] / (float)calcCount * 100f).ToString() + "%\n";
            }

            Debug.Log(logText);
        }
    }
}
