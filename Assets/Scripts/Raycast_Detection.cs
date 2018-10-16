using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    /// <summary>レイキャストの処理を行うクラス</summary>
    public class Raycast_Detection : MonoBehaviour
    {
        /// <summary>レイキャスト発射座標と方向の情報 : Infomation of origin position and direction </summary>
        private Ray2D m_ray2d;
        /// <summary>ヒットしたオブジェクトの情報 : Information of hit Game object</summary>
        private RaycastHit2D m_raycastHit2d;
        /// <summary>レイキャストの射程距離 : Raycast range</summary>
        private float m_distance;

        /// <summary>引数のタッチ情報を元にレイキャスト処理を行いヒットしたゲームオブジェクトを返す</summary>
        /// <param name="touch">Input.GetTouchから得たタッチ情報 : Touch information obtained from Input.GetTouch</param>
        /// <returns>ヒットしたゲームオブジェクト : Hited Game object</returns>
        public GameObject DetectHitGameObject(Touch touch)
        {
            m_ray2d = new Ray2D(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            m_raycastHit2d = Physics2D.Raycast(m_ray2d.origin, m_ray2d.direction);

            if (m_raycastHit2d && m_raycastHit2d.collider.gameObject != null) //Physics2D.Raycastがtrue且つゲームオブジェクトがnullじゃなければ
            {
                return m_raycastHit2d.collider.gameObject; //Hitしたゲームオブジェクトを返す
            }
            else
            {
                return null;
            }
        }
    }
}

