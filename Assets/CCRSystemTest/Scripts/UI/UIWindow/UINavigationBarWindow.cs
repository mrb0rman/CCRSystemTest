using System;
using Doozy.Runtime.UIManager.Components;
using UnityEngine;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UINavigationBarWindow : UIWindow
        {
            [SerializeField] private UIToggle clickerToggle;
            [SerializeField] private UIToggle sunToggle;
            [SerializeField] private UIToggle dogToggle;
            
            [Inject]
            private void Init()
            {
                clickerToggle.OnToggleOnCallback.Event.AddListener(()=>
                {
                    ShowWindow(_uiService.Get<UIClickerWindow>());
                });
                
                clickerToggle.OnToggleOffCallback.Event.AddListener(()=>
                {
                    HideWindow(_uiService.Get<UIClickerWindow>());
                });
                
                sunToggle.OnToggleOnCallback.Event.AddListener(()=>
                {
                    ShowWindow(_uiService.Get<UIWeatherWindow>());
                });
                
                sunToggle.OnToggleOffCallback.Event.AddListener(()=>
                {
                    HideWindow(_uiService.Get<UIWeatherWindow>());
                });
                
                dogToggle.OnToggleOnCallback.Event.AddListener(()=>
                {
                    ShowWindow(_uiService.Get<UIDogWindow>());
                });
                
                dogToggle.OnToggleOffCallback.Event.AddListener(()=>
                {
                    HideWindow(_uiService.Get<UIDogWindow>());
                });
            }
            
            private void ShowWindow(UIWindow uiWindow)
            {
                uiWindow.Show();
            }

            private void HideWindow(UIWindow uiWindow)
            {
                uiWindow.Hide();
            }
            
        }
    }
}

