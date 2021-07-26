using System;

// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public interface ITypeMap : IReadonlyTypeMap
    {
        void Add(Type type, object instance);
        void Add<T>(object instance);
    }
}