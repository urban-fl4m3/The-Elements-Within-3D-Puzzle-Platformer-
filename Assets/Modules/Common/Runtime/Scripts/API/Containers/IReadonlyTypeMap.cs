using System;

// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public interface IReadonlyTypeMap
    {
        object Resolve(Type type);
        T Resolve<T>() where T : class;
    }
}