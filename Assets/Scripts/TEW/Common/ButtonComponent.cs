using System.Collections.Generic;
using Modules.Common.Runtime;
using TEW.Common.Components;
using UnityEngine;

namespace TEW.Common
{
    public class ButtonComponent: IMechanismComponent
    {
        
        private readonly IReadonlyDynamicProperty<bool> _state;
        private readonly List<Mechanism> _toActivate;

        public ButtonComponent(IReadonlyDynamicProperty<bool> state, List<Mechanism> toActivate)
        {
            _state = state;
            _toActivate = toActivate;
            
            TurnOn(_state.Value);
        }
        
        public void Activate()
        {
            _state.Changed += HandleMechanismStateChanged;
        }

        public void Deactivate()
        {
            _state.Changed -= HandleMechanismStateChanged;
        }
        
        private void HandleMechanismStateChanged(object sender, bool e)
        {
            TurnOn(e);
        }
        
        private void TurnOn(bool enable)
        {
            foreach (var mechanism in _toActivate)
            {
                mechanism.IsEnabled.Value = enable;
            }
        }
        
    }
}