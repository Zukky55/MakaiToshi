using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DemonicCity.BattleScene
{
    /// <summary>パネルを生成するクラス</summary>
    public class Instantiate_Panels : MonoBehaviour
    {
        /// <summary>各パネルの生成座標</summary>
        private List<Vector3> m_panelPositions;
        /// <summary>パネルのゲームオブジェクト</summary>
        private GameObject m_panelObject;
        /// <summary>PanelTypeの要素数 : Element count of PanelType</summary>
        private int m_elementCount;
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
        /// <summary>スプライトを初期化するクラス</summary>
        private Initialize_Sprite m_initializeSprite;
        private Panel m_panel;
        private GameObject m_go;
        private int m_elementNum;

        private void Init()
        {
            m_panelPositions = new List<Vector3>　//ゲーム画面の各パネルの位置
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
            m_panelObject = Resources.Load<GameObject>("Battle_Panel"); //Battle_PanelをResourcesフォルダに入れてシーン外から取得
            m_initializeSprite = GetComponent<Initialize_Sprite>();

        }

        private void Awake()
        {
            Init();
        }

        /// <summary>
        /// パネル生成メソッド。
        /// ここでPanelTypeの決定を行う。
        /// PanelTypeの要素数に応じたランダムなPanelTypeを各パネルに渡す。
        /// 各特殊パネルが特定数出現したら、それ以上は選ばれてもCityPanelになる様にする
        /// </summary>
        public void GeneratePanels()
        {
            foreach (var panelPosition in m_panelPositions)//パネルの個数分生成する
            {
                m_go = Instantiate(m_panelObject, panelPosition, Quaternion.identity);// Instantiateして、そのオブジェクトの参照を代入する
                m_panel = m_go.GetComponent<Panel>();
                m_elementNum = Generate_Random_Number.PanelNumber(m_elementCount);// パネル種類の要素数を引数に渡してその要素数を元に乱数生成する
                m_panel.m_panelType = m_initializeSprite.InitializeSprite((PanelType)m_elementNum); //パネルの出現状況に応じてパネルの種類を変える処理を施す
            }
        }
    }
}
