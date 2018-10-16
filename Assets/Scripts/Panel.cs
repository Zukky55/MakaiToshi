using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonicCity.BattleScene   
{
    public enum PanelType
    {
        City,
        CityTimes2,
        CityTimes3,
        Enemy
    }

    public class Panel : MonoBehaviour
    {
        public PanelType m_panelType { get; set; }
    }
}
