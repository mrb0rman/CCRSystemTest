using System;
using CCRSystemTest.Scripts.Command;
using CCRSystemTest.Scripts.UI;
using Zenject;

namespace CCRSystemTest.Scripts
{
    public class ApplicationLaunch
    {
        private readonly UIClickerController _uiClickerController;
        private Bootstrap.Bootstrap _bootstrap;

        public ApplicationLaunch(
            IInstantiator instantiator,
            UIClickerController uiClickerController)
        {
            _uiClickerController = uiClickerController;
            _bootstrap = new Bootstrap.Bootstrap();
            
            _bootstrap.AddCommand(instantiator.Instantiate<SetupUIRootCommand>());
            _bootstrap.AddCommand(instantiator.Instantiate<SetupUIControllerCommand>());
            
            _bootstrap.AllCommandsDone += AllCommandsDoneHandler;
            _bootstrap.StartExecute();
        }

        private void AllCommandsDoneHandler(object sender, EventArgs e)
        {
            _bootstrap.AllCommandsDone -= AllCommandsDoneHandler;
        }
    }
}

