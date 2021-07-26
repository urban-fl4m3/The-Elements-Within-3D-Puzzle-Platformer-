using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Modules.Actors.Runtime
{
    public abstract class ActorBehaviour : ScriptableObject, IActorBehaviour
    {
        public IEnumerable<ActorData> Data => _data;
        
        [SerializeField] private List<ActorData> _data;
        
        public void Create(IActor owner)
        {
            CreateCallback(owner);
        }
        
        public void Activate()
        {
            ActivateCallback();
        }

        public void Deactivate()
        {
            DeactivateCallback();
        }

        public void Dispose()
        {
            DisposeCallback();
        }

        protected abstract void CreateCallback(IActor owner);
        protected abstract void ActivateCallback();
        protected abstract void DeactivateCallback();
        protected abstract void DisposeCallback();
    }
}