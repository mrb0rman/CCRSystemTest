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

            public SetupUIControllerCommand(
                IUIService uiService,
                CommandStorage commandStorage,
                UINavigationBarController uiNavigationBarController,
                UIClickerController uiClickerController) : base(commandStorage)
            {
                _uiService = uiService;
                _uiNavigationBarController = uiNavigationBarController;
                _uiClickerController = uiClickerController;
            }
            
            public override CommandResult Execute()
            {
                _uiClickerController.Init();
                _uiNavigationBarController.Init();
                
                Done?.Invoke(this, EventArgs.Empty);
            
                return base.Execute();
            }
        }
    }
}

