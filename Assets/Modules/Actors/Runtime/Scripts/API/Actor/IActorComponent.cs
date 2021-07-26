using System;

// ReSharper disable once CheckNamespace
namespace Modules.Actors.Runtime
{
    public interface IActorComponent : IDisposable
    {
        void Create(IActor owner);
    }
}