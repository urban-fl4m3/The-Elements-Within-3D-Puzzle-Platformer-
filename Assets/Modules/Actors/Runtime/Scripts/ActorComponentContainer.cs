using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Modules.Actors.Runtime
{
    internal class ActorComponentContainer<TComponent> where TComponent : class, IActorComponent
    {
        public IEnumerable<TComponent> Components => _components.Select(x => x.Value);
        
        private readonly Dictionary<Type, TComponent> _components = new Dictionary<Type, TComponent>();
        private readonly Dictionary<Type, int> _componentsCount = new Dictionary<Type, int>();
        
        public T GetComponent<T>() where T : TComponent, IActorComponent
        {
            var t = typeof(T);
            if (!_components.ContainsKey(t))
            {
                throw new ArgumentException($"{ToString()} doesn't have {t.Name}");
            }

            return (T)_components[t];
        }

        public bool AddComponent(TComponent actorMember)
        {
            var memberType = actorMember.GetType();
            
            if (_componentsCount.ContainsKey(memberType))
            {
                _componentsCount[memberType]++;
                return false;
            }
            
            _components.Add(memberType, actorMember);
            _componentsCount.Add(memberType, 1);

            return true;
        }

        public bool RemoveComponent(Type type, out TComponent removedComponent)
        {
            removedComponent = null;
            if (!_componentsCount.ContainsKey(type))
            {
                return false;
            }
            
            _componentsCount[type]--;

            if (_componentsCount[type] > 0)
            {
                return false;
            }
            
            _components.Remove(type);
            _componentsCount.Remove(type);

            removedComponent = _components[type];
            return true;
        }

        public void Clear()
        {
            foreach (var component in _components)
            {
                component.Value.Dispose();
            }
            
            _components.Clear();
            _componentsCount.Clear();
        }
    }
}