using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    /// <summary>パネルの出現状況に応じてパネルの種類を変える処理を施すクラス。</summary>
    public class Initialize_Sprite : MonoBehaviour
    {
        /// <summary>EnemyPanelが特定数出たら建てるフラグ</summary>
        private bool m_enemyFlag = false;
        /// <summary>パネルが特定数出たら建てるフラグ</summary>
        private bool m_cityTimes2Flag = false;
        /// <summary>パネルが特定数出たら建てるフラグ</summary>
        private bool m_cityTimes3Flag = false;
        /// <summary>パネルが出たら記録するカウント</summary>
        private int m_enemyCount = 0;
        /// <summary>パネルが出たら記録するカウント</summary>
        private int m_cityTimes2Count = 0;
        /// <summary>パネルが出たら記録するカウント</summary>
        private int m_cityTimes3Count = 0;


        /// <summary>
        /// パネルの出現状況に応じてパネルの種類を変える処理を施す。
        ///生成したパネルの種類に応じてカウントを取る。
        ///パネルの生成カウントが指定値に達したらそれ以上生成してもCityPanelになる様にする
        /// </summary>
        /// <param name="panelType">PanelType</param>
        /// <returns>処理を施したパネル</returns>
        public PanelType InitializeSprite(PanelType panelType)
        {
            switch (panelType)
            {
                case PanelType.CityTimes2:
                    if (m_cityTimes2Flag)
                    {
                        return PanelType.City;
                    }
                    else
                    {
                        m_cityTimes2Count++;
                        if (m_cityTimes2Count > 0)
                        {
                            m_cityTimes2Flag = true;
                        }
                    }
                    return panelType;
                case PanelType.CityTimes3:
                    if (m_cityTimes3Flag)
                    {
                        return PanelType.City;
                    }
                    else
                    {
                        m_cityTimes3Count++;
                        if (m_cityTimes3Count > 0)
                        {
                            m_cityTimes3Flag = true;
                        }
                    }
                    return panelType;
                case PanelType.Enemy:

                    if (m_enemyFlag)
                    {
                        return PanelType.City;
                    }
                    else
                    {
                        m_enemyCount++;
                        if (m_enemyCount > 1)
                        {
                            m_enemyFlag = true;
                        }
                    }
                    return panelType;
                case PanelType.City:
                default:
                    return panelType;
            }
        }

    }
}
