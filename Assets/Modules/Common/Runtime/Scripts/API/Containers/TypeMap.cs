using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public class TypeMap : ITypeMap
    {
        private readonly Dictionary<Type, object> _map = new Dictionary<Type, object>();

        public void Add(Type type, object instance)
        {
            _map.Add(type, instance);
        }
        
        public void Add<T>(object instance)
        {
            _map.Add(typeof(T), instance);
        }
        
        public object Resolve(Type type)
        {
            return _map.ContainsKey(type) ? _map[type] : null;
        }

        public T Resolve<T>() where T : class
        {
            return _map.ContainsKey(typeof(T)) ? _map[typeof(T)] as T : null;
        }
    }
}