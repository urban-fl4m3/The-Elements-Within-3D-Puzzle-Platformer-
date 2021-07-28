using System.Collections.Generic;
using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common
{
    public class InputManager: ITickUpdate
    {
        private Dictionary<string,DynamicDynamicProperty<float>> _inputAxisList;
        private Dictionary<KeyCode,DynamicDynamicProperty<bool>> _inputButtonDownList;

        public bool Enabled { get; set; }
        public void Tick()
        {
            foreach (var dynamicProperty in _inputAxisList)
            {
                dynamicProperty.Value.Value = Input.GetAxis(dynamicProperty.Key);
            }
            foreach (var dynamicProperty in _inputButtonDownList)
            {
                dynamicProperty.Value.Value = Input.GetKeyDown(dynamicProperty.Key);
            }
        }

        public DynamicDynamicProperty<float> AddAxisButton(string axis)
        {
           _inputAxisList.Add(axis, new DynamicDynamicProperty<float>());
           return _inputAxisList[axis];
        }

        public DynamicDynamicProperty<bool> AddButtonDown(KeyCode keyCode)
        {
            _inputButtonDownList.Add(keyCode,new DynamicDynamicProperty<bool>(false));
            return _inputButtonDownList[keyCode];
        }

    }
}