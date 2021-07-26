using System;

// ReSharper disable once CheckNamespace
namespace Modules.Commands.Runtime
{
    public interface ICommand
    {
        event EventHandler OnComplete;
        event EventHandler OnFail;
        
        void Execute();
    }
}