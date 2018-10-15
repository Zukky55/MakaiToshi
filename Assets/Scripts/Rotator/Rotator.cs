using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    public class Rotator : MonoBehaviour
    {
        /// <summary>角速度 : angular velocity</summary>
        private float m_angularVelocity = 0f;
        private Quaternion m_currentRot;
        private Change_Sprite m_changeSprite;
        private bool m_frag = true;

        /// <summary>初期化 : Initialize</summary>
        private void Init()
        {
            m_changeSprite = GetComponent<Change_Sprite>();
        }

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            Deceleration();
            Rotation();
        }


        /// <summary>タッチする度加速させる</summary>
        public void Acceleration()
        {
            m_angularVelocity += 10f;
            Battle_Manager.m_panelProcessingFlag = false;
            if(m_angularVelocity == 0f)
            {
                Battle_Manager.m_panelProcessingFlag = true;
            }
        }

        /// <summary>角速度が0より上の場合徐々に減速させていく</summary>
        public void Deceleration()
        {
            if (m_angularVelocity > 0f)
            {
                m_angularVelocity -= m_angularVelocity * Time.deltaTime;
            }
            if (m_angularVelocity < 0.01f && m_angularVelocity > 0f) 
            {
                Debug.Log("よばれたお");
                Debug.Break();
                m_angularVelocity = 0f;
                m_frag = true;
            }

        }

        /// <summary>角速度>1の時マイフレーム毎にy軸に対して回転を掛ける : When angular velocity > 1, rotate it with respect to the y axis for each my frame</summary>
        public void Rotation()
        {
            if (m_angularVelocity > 1f)
            {
                transform.Rotate(Vector3.up, m_angularVelocity);
            }
            else if (m_angularVelocity <= 1f && m_angularVelocity > 0f)
            {
                RotationAdjustment();
            }
        }

        /// <summary>回転調整。角速度が0に近づいたら無回転状態になる様回転を調整する</summary>
        public void RotationAdjustment()
        {
            if(m_frag)
            {
                m_changeSprite.Excute();
                m_frag = false;
            }

            m_currentRot = transform.rotation;
            transform.rotation = Quaternion.Slerp(m_currentRot, Quaternion.identity, Time.deltaTime);
        }
    }
}
