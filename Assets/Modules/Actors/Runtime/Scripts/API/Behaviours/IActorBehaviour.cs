using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Modules.Actors.Runtime
{
    public interface IActorBehaviour : IActorComponent
    {
        IEnumerable<ActorData> Data { get; }

        void Activate();
        void Deactivate();
    }
}