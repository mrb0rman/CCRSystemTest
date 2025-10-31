using System;
using CCRSystemTest.Scripts.UI;

namespace CCRSystemTest.Scripts
{
    namespace Command
    {
        public class SetupUIControllerCommand : Command
        {
            private readonly IUIService _uiService;
            private readonly UINavigationBarController _uiNavigationBarController;
            private readonly UIClickerController _uiClickerController;
            private readonly UIWeatherController _uiWeatherController;
            private readonly UIDogController _uiDogController;

            public SetupUIControllerCommand(
                IUIService uiService,
                CommandStorage commandStorage,
                UINavigationBarController uiNavigationBarController,
                UIClickerController uiClickerController,
                UIWeatherController uiWeatherController,
                UIDogController uiDogController) : base(commandStorage)
            {
                _uiService = uiService;
                _uiNavigationBarController = uiNavigationBarController;
                _uiClickerController = uiClickerController;
                _uiWeatherController = uiWeatherController;
                _uiDogController = uiDogController;
            }
            
            public override CommandResult Execute()
            {
                _uiNavigationBarController.Init();
                _uiClickerController.Init();
                _uiWeatherController.Init();
                _uiWeatherController.Init();
                _uiDogController.Init();
                
                Done?.Invoke(this, EventArgs.Empty);
            
                return base.Execute();
            }
        }
    }
}

