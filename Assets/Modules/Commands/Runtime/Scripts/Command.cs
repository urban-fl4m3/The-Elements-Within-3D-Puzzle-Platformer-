using System;

// ReSharper disable once CheckNamespace
namespace Modules.Commands.Runtime
{
    public abstract class Command : ICommand
    {
        public event EventHandler OnComplete;
        public event EventHandler OnFail;
        
        public abstract void Execute();

        protected void CompleteCommand()
        {
            OnComplete?.Invoke(this, EventArgs.Empty);
        }

        protected void FailedCommand()
        {
            OnFail?.Invoke(this, EventArgs.Empty);    
        }
    }
}