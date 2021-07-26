using System;

// ReSharper disable once CheckNamespace
namespace Modules.Common.Runtime
{
    public class DynamicDynamicProperty<T> : IDynamicProperty<T>, IReadonlyDynamicProperty<T>
    {
        public event EventHandler<T> Changed;
        
        private T _value;
        
        public DynamicDynamicProperty(T value)
        {
            _value = value;
        }

        public DynamicDynamicProperty()
        {
            _value = default;
        }

        public T Value
        {
            get => _value;
            set
            {
                if ((_value == null && value != null))
                {
                    _value = value;
                    Changed?.Invoke(this, value);
                }
                else if (_value != null && !_value.Equals(value))
                {
                    _value = value;
                    Changed?.Invoke(this, value);
                }
            }
        }
    }
}