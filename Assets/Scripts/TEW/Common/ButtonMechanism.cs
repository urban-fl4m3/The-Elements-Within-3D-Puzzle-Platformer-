using System.Collections.Generic;
using Modules.Common.Runtime;
using TEW.Common.Components;
using TEW.Common.World.Interactive;
using UnityEngine;

namespace TEW.Common
{
    public class ButtonMechanism: Mechanism, IInteractable
    {
        public override IReadonlyDynamicProperty<bool> IsEnabled => _isEnabled;
        protected override IEnumerable<IMechanismComponent> MechanismComponents => _components;
        
        private readonly DynamicProperty<bool> _isEnabled = new DynamicProperty<bool>(false);
        private readonly List<IMechanismComponent> _components = new List<IMechanismComponent>();
        [SerializeField] private List<Mechanism> toOn;
        
        protected override void CreateCallback()
        {
            _components.Add(new ButtonComponent(_isEnabled,toOn));
        }

        protected override void DestroyCallback()
        {
          _components.Clear();
        }

        protected override void ActivateCallback()
        {
           
        }

        protected override void DeactivateCallback()
        {
          
        }

        public void Interact()
        {
            _isEnabled.Value = ! _isEnabled.Value;
        }
    }
}