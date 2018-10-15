using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene   
{
    public enum PanelType
    {
        Default,
        City,
        CityTimes2,
        CityTimes3,
        Enemy
    }


    public class Panel : MonoBehaviour
    {
        /// <summary>タッチ情報格納オブジェクト : Touch information strorage object</summary>
        private Touch m_touch;
        /// <summary>ファクトリークラス。Touch情報をもとに適切な処理を行ってくれる</summary>
        private Touch_Info_Factory m_touchInfoFactory;
        private PanelType m_panelType;

        /// <summary>初期化メソッド : Initialize method</summary>
        private void Init()
        {
            m_touchInfoFactory = GetComponent<Touch_Info_Factory>();
        }

        /// <summary>スタートメソッド : Start method</summary>
        private void Start()
        {
            //Debug.Log( "Transform.position is " + transform.position);
            Init(); //初期化 : Initialize 
            
            
        }

        /// <summary>アップデートメソッド : Update method</summary>
        public void Update()
        {
            if (Input.touchCount > 0) //タッチされているかのチェック : Confirm whether it is touched.
            {
                m_touch = Input.GetTouch(0); //タッチ情報の取得 : Acquire touch information.
                m_touchInfoFactory.OperationPerTouch(m_touch);
            }
        }

        /// <summary>呼び出し元で設定した値に沿ってタイプを変える</summary>
        /// <param name="num">PanelTypeに変換する数値</param>
        public void SetPanelType(int num)
        {
            m_panelType = (PanelType)num;
        }

    }
}
