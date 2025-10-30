using System;

namespace CCRSystemTest.Scripts
{
    namespace Command
    { 
        public interface ICommand
        {
            EventHandler Done { get; set; }
            
            CommandResult Execute();
        
            CommandResult Undo();
        
            CommandResult Redo();
            
            void Cancel();
        }
    }
}

