using System;
using CCRSystemTest.Scripts.UI;

namespace CCRSystemTest.Scripts
{
    namespace Command
    {
        public class SetupUIRootCommand : Command
        {
            private readonly IUIService _uiService;
            private readonly CameraView _cameraView;

            public SetupUIRootCommand(
                IUIService uiService,
                CommandStorage commandStorage,
                CameraView cameraView) : base(commandStorage)
            {
                _uiService = uiService;
                _cameraView = cameraView;
            }
            
            public override CommandResult Execute()
            {
                _uiService.LoadWindows();
                _uiService.InitWindows(_cameraView.Camera);
                
                Done?.Invoke(this, EventArgs.Empty);
            
                return base.Execute();
            }
        }
    }
}

