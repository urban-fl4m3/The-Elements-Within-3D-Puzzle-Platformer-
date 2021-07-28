using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common
{
    public class InputControl : ITickUpdate
    {
        private DynamicDynamicProperty<bool> _dynamicProperty;
        private readonly KeyCode _inputKeyCode;

        public InputControl(DynamicDynamicProperty<bool> dynamicProperty, KeyCode keyCode)
        {
            _dynamicProperty = dynamicProperty;
            _inputKeyCode = keyCode;
        }

        public bool Enabled { get; set; }

        public void Tick()
        {
            if (Input.GetKeyDown(_inputKeyCode))
            {
                _dynamicProperty.Value = !_dynamicProperty.Value;
            }
        }
    }
}