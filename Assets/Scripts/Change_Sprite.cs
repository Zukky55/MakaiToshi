using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene
{
    /// <summary>Spriteをランダムで切り替えるクラス</summary>
    public class Change_Sprite : MonoBehaviour,I_Executable
    {
        [SerializeField] private Sprite[] m_panels;
        private SpriteRenderer m_spriteRender;
        private PanelType m_panelType;
        
    
        /// <summary>Interface_Excutableのインターフェース : Interface of Interface_Startable</summary>
        public void Excute()
        {
            ChangingSprite();
        }

        /// <summary>初期化</summary>
        private void Init()
        {
            m_spriteRender = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            Init();
        }

        /// <summary>スプライトを変更させる : Changing sprite</summary>
        public void ChangingSprite()
        {
            m_panelType = (PanelType)Random.Range(1, 3);
            m_spriteRender.sprite = m_panels[(int)m_panelType];
        }

    }
}
