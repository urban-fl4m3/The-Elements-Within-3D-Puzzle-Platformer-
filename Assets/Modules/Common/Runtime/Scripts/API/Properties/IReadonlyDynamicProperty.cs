using System;

// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public interface IReadonlyDynamicProperty<T> : IReadonlyProperty<T>
    {
        event EventHandler<T> Changed;
    }
}