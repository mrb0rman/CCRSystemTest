using CCRSystemTest.Scripts.UI;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    public class NavigationBarController
    {
        private readonly UINavigationBarController _uiNavigationBarController;
        private readonly UIClickerController _uiClickerController;

        public NavigationBarController(
            UINavigationBarController uiNavigationBarController,
            UIClickerController uiClickerController)
        {
            _uiNavigationBarController = uiNavigationBarController;
            _uiClickerController = uiClickerController;

            _uiNavigationBarController.ShowWindowEvent += HandlerShowWindowEvent;
            _uiNavigationBarController.HideWindowEvent += HandlerHideWindowEvent;
        }
        
        private void HandlerShowWindowEvent(UIWindow uiWindow)
        {
            switch (uiWindow)
            {
                case UIClickerWindow:
                    break;
                case UIWeatherWindow:
                    
                    break;
                case UIDogWindow:
                    
                    break;
            }
        }
        
        private void HandlerHideWindowEvent(UIWindow uiWindow)
        {
            switch (uiWindow)
            {
                case UIClickerWindow:
                    
                    break;
                case UIWeatherWindow:
                    
                    break;
                case UIDogWindow:
                    
                    break;
            }
        }
    }
}

