using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common
{
    public class PropertyStateInputToggle : ITickUpdate
    {
        public bool Enabled { get; set; }
        
        private readonly DynamicProperty<bool> _changeableProperty;
        private readonly KeyCode _inputKeyCode;

        public PropertyStateInputToggle(DynamicProperty<bool> changeableProperty, KeyCode keyCode)
        {
            _changeableProperty = changeableProperty;
            _inputKeyCode = keyCode;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(_inputKeyCode))
            {
                _changeableProperty.Value = !_changeableProperty.Value;
            }
        }
    }
}