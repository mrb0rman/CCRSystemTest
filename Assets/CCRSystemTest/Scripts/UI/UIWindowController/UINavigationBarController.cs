using System;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UINavigationBarController
        {
            public Action<UIWindow> ShowWindowEvent;
            public Action<UIWindow> HideWindowEvent;
            
            private readonly IUIService _uiService;
            private UINavigationBarWindow _uiNavigationBarWindow;

            public UINavigationBarController(
                IUIService uiService)
            {
                _uiService = uiService;
            }

            public void Init()
            {
                _uiNavigationBarWindow = _uiService.Get<UINavigationBarWindow>();
                ShowWindowEvent?.Invoke(_uiService.Show<UIClickerWindow>());
                
                _uiNavigationBarWindow.ClickerToggle.OnToggleOnCallback.Event.AddListener(()=>
                {
                    _uiNavigationBarWindow.ClickerToggle.isLocked = true;
                    ShowWindow(_uiService.Get<UIClickerWindow>());
                });
                
                _uiNavigationBarWindow.ClickerToggle.OnToggleOffCallback.Event.AddListener(()=>
                {
                    HideWindow(_uiService.Get<UIClickerWindow>());
                });
                
                _uiNavigationBarWindow.SunToggle.OnToggleOnCallback.Event.AddListener(()=>
                {
                    _uiNavigationBarWindow.SunToggle.isLocked = true;
                    ShowWindow(_uiService.Get<UIWeatherWindow>());
                });
                
                _uiNavigationBarWindow.SunToggle.OnToggleOffCallback.Event.AddListener(()=>
                {
                    HideWindow(_uiService.Get<UIWeatherWindow>());
                });
                
                _uiNavigationBarWindow.DogToggle.OnToggleOnCallback.Event.AddListener(()=>
                {
                    _uiNavigationBarWindow.DogToggle.isLocked = true;
                    ShowWindow(_uiService.Get<UIDogWindow>());
                });
                
                _uiNavigationBarWindow.DogToggle.OnToggleOffCallback.Event.AddListener(()=>
                {
                    HideWindow(_uiService.Get<UIDogWindow>());
                });
                
                _uiNavigationBarWindow.ClickerToggle.isLocked = true;
            }
            
            private void ShowWindow(UIWindow uiWindow)
            {
                uiWindow.Show();
                ShowWindowEvent?.Invoke(uiWindow);
            }

            private void HideWindow(UIWindow uiWindow)
            {
                uiWindow.Hide();
                HideWindowEvent?.Invoke(uiWindow);
            }
        }
    }
}

