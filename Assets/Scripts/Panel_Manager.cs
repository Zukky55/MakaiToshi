using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    public class Panel_Manager : MonoBehaviour
    {
        /// <summary>
        /// 各パネルが作動しているかどうかを判断するフラグ。
        /// いずれかのパネルがタッチされた瞬間falseへ。
        /// パネルが停止し処理が完了したらtrueへ。
        /// </summary>
        public static bool m_panelProcessingFlag { get; set; }
        /// <summary>タッチ情報格納オブジェクト : Touch information strorage object</summary>
        private Touch m_touch;
        /// <summary>ファクトリークラス。Touch情報をもとに適切な処理を行ってくれる</summary>
        private Touch_Info_Factory m_touchInfoFactory;
        private Raycast_Detection m_raycastDetection;
        private GameObject m_go;

        /// <summary>初期化 : Initialize</summary>
        private void Init()
        {
            m_panelProcessingFlag = true;
            m_raycastDetection = GetComponent<Raycast_Detection>();
        }

        private void Start()
        {
            Init();
            Instantiate_Panels ip = GetComponent<Instantiate_Panels>();
            ip.GeneratePanels();
        }

        /// <summary>アップデートメソッド : Update method</summary>
        public void Update()
        {
            if (Input.touchCount > 0 && m_panelProcessingFlag) //タッチされている＆パネルの処理を行っていない場合タッチ処理を行う
            {
                m_touch = Input.GetTouch(0); //タッチ情報の取得 : Acquire touch information.
                m_go = m_raycastDetection.DetectHitGameObject(m_touch);
                if(m_go != null)
                {
                    m_touchInfoFactory = m_go.GetComponent<Touch_Info_Factory>();
                    m_touchInfoFactory.OperationPerTouch(m_touch);　//タッチ情報を渡して処理を行ってもらう
                }
            }
        }
    }
}

