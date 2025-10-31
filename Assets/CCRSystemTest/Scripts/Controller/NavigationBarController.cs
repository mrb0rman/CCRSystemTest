using CCRSystemTest.Scripts.UI;

namespace CCRSystemTest.Scripts
{
    namespace Controller
    {
        public class NavigationBarController
        {
            private readonly UIClickerController _uiClickerController;
            private readonly UIWeatherController _uiWeatherController;
            private readonly UIDogController _uiDogController;

            public NavigationBarController(
                UINavigationBarController uiNavigationBarController,
                UIClickerController uiClickerController,
                UIWeatherController uiWeatherController,
                UIDogController uiDogController)
            {
                _uiClickerController = uiClickerController;
                _uiWeatherController = uiWeatherController;
                _uiDogController = uiDogController;

                uiNavigationBarController.ShowWindowEvent += HandlerShowWindowEvent;
                uiNavigationBarController.HideWindowEvent += HandlerHideWindowEvent;
            }
        
            private void HandlerShowWindowEvent(UIWindow uiWindow)
            {
                switch (uiWindow)
                {
                    case UIClickerWindow:
                        _uiClickerController.StartClicker();
                        break;
                    case UIWeatherWindow:
                        _uiWeatherController.StartWeatherRequest();
                        break;
                    case UIDogWindow:
                        _uiDogController.StartDogRequest();
                        break;
                }
            }
        
            private void HandlerHideWindowEvent(UIWindow uiWindow)
            {
                switch (uiWindow)
                {
                    case UIClickerWindow:
                        _uiClickerController.StopClicker();
                        break;
                    case UIWeatherWindow:
                        _uiWeatherController.StopWeatherRequest();
                        break;
                    case UIDogWindow:
                        _uiDogController.StopDogRequest();
                        break;
                }
            }
        }
    }
}