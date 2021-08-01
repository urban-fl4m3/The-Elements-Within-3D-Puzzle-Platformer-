// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public interface IReadonlyProperty<T>
    {
        public T Value { get; set; }
    }
}