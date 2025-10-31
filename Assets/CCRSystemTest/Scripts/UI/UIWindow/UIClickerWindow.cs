using Doozy.Runtime.UIManager.Components;
using TMPro;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UIClickerWindow : UIWindow
        {
            public UIButton CoinButton => coinButton;
            public TMP_Text CurrentScoreTMPText => currentScoreTMPText;
            public TMP_Text CurrentEnergyTMPText => currentEnergyTMPText;
            public TMP_Text MaxEnergyTMPText => maxEnergyTMPText;
            [SerializeField] private UIButton coinButton;
            [SerializeField] private TMP_Text currentScoreTMPText;
            [SerializeField] private TMP_Text currentEnergyTMPText;
            [SerializeField] private TMP_Text maxEnergyTMPText;
        }
    }
}