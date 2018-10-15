using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DemonicCity.BattleScene
{

    ///// <summary>乱数生成の処理を委譲する</summary>
    ///// <returns>乱数</returns>
    //delegate int RandomNum();

    public class Instantiate_Panels : MonoBehaviour
    {
        /// <summary>各パネルの生成座標</summary>
        private List<Vector3> m_panelPositions;
        private GameObject m_panelObject;
        /// <summary>PanelTypeの要素数 : Element count of PanelType</summary>
        private int m_elementCount;

        private int m_city = 5;
        private int m_cityTimes2 = 1;
        private int m_cityTimes3 = 1;
        private int m_enemy = 2;


        private void Init()
        {
            m_panelPositions = new List<Vector3>
            {
                new Vector3(-1.4f,-4.7f,0.0f),
                new Vector3(-1.4f,-3.2f,0.0f),
                new Vector3(-1.4f,-1.8f,0.0f),
                new Vector3(0.0f,-4.7f,0.0f),
                new Vector3(0.0f,-3.2f,0.0f),
                new Vector3(0.0f,-1.8f,0.0f),
                new Vector3(1.4f,-4.7f,0.0f),
                new Vector3(1.4f,-3.2f,0.0f),
                new Vector3(1.4f,-1.8f,0.0f),
            };
            m_elementCount = Enum.GetValues(typeof(PanelType)).Length; //PanelTypeを配列に変換し要素数取得。
            //m_panelObject = GameObject.Find("Assets/Prefabs/Battle_/Battle_Panel.prefab"); //PathでBattle_Panelオブジェクト取得。
            m_panelObject = Resources.Load<GameObject>("Battle_Panel");

        }

        private void Awake()
        {
            Init();
        }

        /// <summary>
        /// パネル生成メソッド。
        /// ここでPanelTypeの決定を行う。
        /// PanelTypeの要素数に応じたランダムなPanelTypeを各パネルに渡す。
        /// PanelType.Enemyが二つ生成されたらそれ以上PanelType.Enemyが選ばれない様にする
        /// </summary>
        public void GeneratePanels()
        {
            foreach (var panelPosition in m_panelPositions)
            {
                GameObject go = Instantiate(m_panelObject, panelPosition, Quaternion.identity);
                Panel panel = go.GetComponent<Panel>();
                var num = Generate_Random_Number.PanelNumber(m_elementCount);
                
            }
        }

    }
}
