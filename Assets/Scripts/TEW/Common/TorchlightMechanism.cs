using System.Collections.Generic;
using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using TEW.Common.Components;
using UnityEngine;

namespace TEW.Common
{
    public class TorchlightMechanism : Mechanism
    {
        public override IReadonlyDynamicProperty<bool> IsEnabled => _isEnabled;
        protected override IEnumerable<IMechanismComponent> MechanismComponents => _components;

        private readonly DynamicProperty<bool> _isEnabled = new DynamicProperty<bool>(false);
        private readonly List<IMechanismComponent> _components = new List<IMechanismComponent>();
        
        private ITickUpdate _inputController;

        [SerializeField] private ParticleSystem _fireSystem;
        [SerializeField] private KeyCode _switchKeyCode;

        protected override void CreateCallback()
        {
            _components.Add(new TorchlightFire(_isEnabled, _fireSystem));
            
            _inputController ??= new PropertyStateInputToggle(_isEnabled, _switchKeyCode);
            TickManager.AddTick(this, _inputController);
        }

        protected override void DestroyCallback()
        {
            _components.Clear();
            TickManager.RemoveTick(_inputController);    
        }

        protected override void ActivateCallback()
        {
            _inputController.Enabled = true;
        }

        protected override void DeactivateCallback()
        {
            _inputController.Enabled = false;
        }
    }
}