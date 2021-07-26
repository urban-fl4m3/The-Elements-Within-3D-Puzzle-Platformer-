using System;

// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public interface IDynamicProperty<T> : IProperty<T>
    {
        public event EventHandler<T> Changed;
    }
}