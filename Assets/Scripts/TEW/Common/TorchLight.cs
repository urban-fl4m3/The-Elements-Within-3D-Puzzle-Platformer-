using System;
using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using UnityEditor.XR;
using UnityEngine;

namespace TEW.Common
{
    public class TorchLight : Mechanism
    {
        private DynamicDynamicProperty<bool> dynamicProperty = new DynamicDynamicProperty<bool>(false);
        public KeyCode KeyCode;
        public override DynamicDynamicProperty<bool> DynamicProperty => dynamicProperty;


        private void Start()
        {
            var inputControl = new InputControl(dynamicProperty, KeyCode);
            TickManager.AddTick(this, inputControl);
        }
    }

}