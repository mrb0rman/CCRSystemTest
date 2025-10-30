using System;
using CCRSystemTest.Scripts.Command;

namespace CCRSystemTest.Scripts
{
    namespace Bootstrap
    {
        public interface IProcessingCommand
        {
            event EventHandler AllCommandsDone;

            bool IsExecuting { get; }

            void AddCommand(ICommand cmd);
            void StartExecute();
            void Clear();

            bool Any();
        }
    }
}
