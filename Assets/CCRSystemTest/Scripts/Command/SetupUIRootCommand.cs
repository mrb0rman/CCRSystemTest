using System;
using CCRSystemTest.Scripts.UI;

namespace CCRSystemTest.Scripts
{
    namespace Command
    {
        public class SetupUIRootCommand : Command
        {
            private readonly IUIService _uiService;

            public SetupUIRootCommand(
                IUIService uiService,
                CommandStorage commandStorage) : base(commandStorage)
            {
                _uiService = uiService;
            }
            
            public override CommandResult Execute()
            {
                _uiService.LoadWindows();
                _uiService.InitWindows();
                
                Done?.Invoke(this, EventArgs.Empty);
            
                return base.Execute();
            }
        }
    }
}

