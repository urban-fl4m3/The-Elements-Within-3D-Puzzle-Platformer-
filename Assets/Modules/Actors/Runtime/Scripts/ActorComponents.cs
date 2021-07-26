using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

// ReSharper disable once CheckNamespace
namespace Modules.Actors.Runtime
{
    [Serializable]
    internal class ActorComponents
    {
        [SerializeField] private List<ActorBehaviour> _exposedBehaviours;
        
        private readonly ActorComponentContainer<IActorBehaviour> _behaviours 
            = new ActorComponentContainer<IActorBehaviour>();
        private readonly ActorComponentContainer<IActorData> _data 
            = new ActorComponentContainer<IActorData>();

        public void AddBehaviour<T>(IActor owner, T behaviour) where T : IActorBehaviour
        {
            foreach (var data in behaviour.Data)
            {
                var instance = Object.Instantiate(data);
                if (_data.AddComponent(instance))
                {
                    instance.Create(owner);
                }
            }

            behaviour.Create(owner);
            _behaviours.AddComponent(behaviour);
        }

        public void RemoveBehaviour(Type behaviourType, out IActorBehaviour removedBehaviour)
        {
            var succeed = _behaviours.RemoveComponent(behaviourType, out var behaviour);
            removedBehaviour = behaviour;
            
            if (!succeed) return;

            foreach (var data in behaviour.Data)
            {
                if (_data.RemoveComponent(data.GetType(), out var removedData))
                {
                    removedData.Dispose();
                }
            }
        }

        public IEnumerable<IActorBehaviour> GetAllBehaviours()
        {
            return _behaviours.Components;
        }
        
        public T GetData<T>() where T : class, IActorData
        {
            return _data.GetComponent<T>();
        }

        public IEnumerable<ActorBehaviour> GetExposedBehaviours()
        {
            return _exposedBehaviours;
        } 
        
        public void Clear()
        {
            _behaviours.Clear();
            _data.Clear();
        }
    }
}