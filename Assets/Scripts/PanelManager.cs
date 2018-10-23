using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    public class PanelManager : MonoBehaviour
    {
        /// <summary>タッチ情報格納オブジェクト : Touch information strorage object</summary>
        private Touch m_touch;
        /// <summary>ファクトリークラス。Touch情報をもとに適切な処理を行ってくれる</summary>
        private TouchInfoFactory m_touchInfoFactory;
        private GameObject m_go;

        private void Start()
        {
            InstantiatePanels ip = GetComponent<InstantiatePanels>();
            ip.GeneratePanels(); //Panel生成処理
        }

        /// <summary>アップデートメソッド : Update method</summary>
        public void Update()
        {
            if (Input.touchCount > 0 ) //タッチされている＆パネルの処理を行っていない場合タッチ処理を行う
            {
                m_touch = Input.GetTouch(0); //タッチ情報の取得 : Acquire touch information.
                m_go = RaycastDetection.DetectHitGameObject(m_touch.position); //タッチ座標を引数にレイキャスト処理を行い当たったゲームオブジェクトを返す
                if(m_go != null)
                {
                    m_touchInfoFactory = m_go.GetComponent<TouchInfoFactory>();
                    m_touchInfoFactory.OperationPerTouch(m_touch);
                }
            }
        }
    }
}

