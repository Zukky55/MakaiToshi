using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    /// <summary>乱数生成クラス</summary>
    public static class Generate_Random_Number
    {
        /// <summary>
        /// パネルの全種類の中からランダムな値を返す。
        /// </summary>
        /// <param name="panelTypes">パネルの種類数</param>
        /// <returns>乱数処理した値</returns>
        public static int PanelNumber(int panelTypes)
        {
            return Random.Range(0,panelTypes);
        }
    }
}

