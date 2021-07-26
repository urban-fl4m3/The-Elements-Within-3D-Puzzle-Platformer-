using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Modules.Actors.Runtime
{
    public abstract class ActorData : ScriptableObject, IActorData
    {
        public void Create(IActor owner)
        {
            CreateCallback(owner);
        }
        
        public void Dispose()
        {
            
        }
        
        protected abstract void CreateCallback(IActor owner);
    }
}