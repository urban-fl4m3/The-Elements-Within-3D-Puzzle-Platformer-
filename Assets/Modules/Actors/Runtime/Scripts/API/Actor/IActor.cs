using System;
using Object = UnityEngine.Object;

// ReSharper disable once CheckNamespace
namespace Modules.Actors.Runtime
{
    public interface IActor
    {   
        void Activate();
        void Deactivate();
        void Destroy();

        void AddBehaviour<T>(T rawBehaviour) where T : ActorBehaviour;
        void RemoveBehaviour(Type behaviourType);
        
        TComponent GetMonoComponent<TComponent>() where TComponent : Object;
        TData GetData<TData>() where TData : class, IActorData;
    }
}