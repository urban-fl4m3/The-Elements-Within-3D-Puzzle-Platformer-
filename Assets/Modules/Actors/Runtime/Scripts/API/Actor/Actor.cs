using System;
using UnityEngine;
using Object = UnityEngine.Object;

// ReSharper disable once CheckNamespace
namespace Modules.Actors.Runtime
{
    public abstract class Actor : MonoBehaviour, IActor
    {
        public GameObject Object => gameObject;
        
        [SerializeField] private ActorComponents _components;

        private void Start()
        {
            _components.Clear();

            foreach (var behaviour in _components.GetExposedBehaviours())
            {
                AddBehaviour(behaviour);
            }

            StartCallback();
        }

        public void Activate()
        {
            foreach (var behaviour in _components.GetAllBehaviours())
            {
                behaviour.Activate();
            }
            
            ActivateCallback();
        }

        public void Deactivate()
        {
            foreach (var behaviour in _components.GetAllBehaviours())
            {
                behaviour.Deactivate();
            }
            
            DeactivateCallback();
        }

        public void Destroy()
        {
            foreach (var behaviour in _components.GetAllBehaviours())
            {
                RemoveBehaviour(behaviour.GetType());    
            }
            
            DestroyCallback();
            
            Destroy(gameObject);
            _components.Clear();
        }

        public void AddBehaviour<T>(T rawBehaviour) where T : ActorBehaviour
        {
            var behaviour = Instantiate(rawBehaviour);
            _components.AddBehaviour(this, behaviour);
        }

        public void RemoveBehaviour(Type behaviourType)
        {
            _components.RemoveBehaviour(behaviourType, out var behaviour);
            behaviour.Dispose();
        }

        public TComponent GetMonoComponent<TComponent>() where TComponent : Object
        {
            return GetComponent<TComponent>();
        }

        public TData GetData<TData>() where TData : class, IActorData
        {
            return _components.GetData<TData>();
        }

        protected abstract void StartCallback();
        protected abstract void ActivateCallback();
        protected abstract void DeactivateCallback();
        protected abstract void DestroyCallback();
    }
}