using Doozy.Runtime.UIManager.Components;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UINavigationBarWindow : UIWindow
        {
            public UIToggle ClickerToggle => clickerToggle;
            public UIToggle SunToggle => sunToggle;
            public UIToggle DogToggle => dogToggle;
            
            [SerializeField] private UIToggle clickerToggle;
            [SerializeField] private UIToggle sunToggle;
            [SerializeField] private UIToggle dogToggle;
        }
    }
}

