using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    public class Battle_Manager : MonoBehaviour
    {
        /// <summary>
        /// 各パネルが作動しているかどうかを判断するフラグ。
        /// いずれかのパネルがタッチされた瞬間falseへ。
        /// パネルが停止し処理が完了したらtrueへ。
        /// </summary>
        public static bool m_panelProcessingFlag { get; set; }

        private void Init()
        {
            m_panelProcessingFlag = true;
        }

        private void Start()
        {
            Init();
            Instantiate_Panels gp = GetComponent<Instantiate_Panels>();
            gp.GeneratePanels();
        }
    }
}

