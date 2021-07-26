using System;

// ReSharper disable once CheckNamespace
namespace Modules.Commands.Runtime
{
    public interface ICommandQueue
    {
        event EventHandler OnComplete;
        
        void Add(ICommand command);
        void ExecuteAll();
    }
}