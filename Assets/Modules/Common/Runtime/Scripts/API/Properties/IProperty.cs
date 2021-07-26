// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public interface IProperty<T>
    {
        T Value { get; set; }
    }
}