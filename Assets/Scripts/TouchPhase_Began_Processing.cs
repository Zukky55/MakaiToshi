using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    /// <summary>
    /// TouchPhase_Beganの処理クラス
    /// もし、TouchPhase.Beganの処理が二つ以上に増えてきたら共通部分だけ残してスーパークラスに変換、継承クラスを個別で作る
    /// </summary>
    public class TouchPhase_Began_Processing : MonoBehaviour,I_Began_Startable
    {
        private Rotator m_rotator;
        private bool m_startFlag = false;

        public void Excute()
        {
            m_rotator.Acceleration();
        }

        private void Init()
        {
            m_rotator = GetComponent<Rotator>();
        }

        private void Start()
        {
            Init();
        }
    }
}