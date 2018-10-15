using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    /// <summary>引数としてきたタッチ情報を元に適切なInterface_Excutableを実装したオブジェクトを返す</summary>
    public class Touch_Info_Factory : MonoBehaviour
    {
        /// <summary>回転処理</summary>
        private Rotator m_rotator;
        /// <summary>レイキャスト処理</summary>
        private Raycast_Detection m_raycastDetection;
        /// <summary>戻り値用変数</summary>
        private GameObject m_go;
        /// <summary>TouchPhase.Began時の処理</summary>
        private TouchPhase_Began_Processing m_touchPhaseBeganProc;

        /// <summary>タッチ判別処理</summary>
        /// <param name="touch">Input.GetTouchのタッチ情報</param>
        public void OperationPerTouch(Touch touch)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    //m_raycastDetection = GetComponent<Raycast_Detection>();
                    //m_go = m_raycastDetection.DetectHitGameObject(touch);
                    m_touchPhaseBeganProc = GetComponent<TouchPhase_Began_Processing>();
                    m_touchPhaseBeganProc.Excute();
                    

                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                default:
                    break;
            }
        }
    }
}
