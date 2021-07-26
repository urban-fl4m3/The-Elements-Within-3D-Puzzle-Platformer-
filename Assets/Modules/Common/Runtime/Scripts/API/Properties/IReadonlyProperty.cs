// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public interface IReadonlyProperty<out T>
    {
        public T Value { get; }
    }
}