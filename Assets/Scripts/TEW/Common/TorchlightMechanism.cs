using System.Collections.Generic;
using System.Threading.Tasks;
using Modules.Common.Runtime;
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

        [SerializeField] private ParticleSystem _fireSystem;
        [SerializeField] private float _timerToOn;
        [SerializeField] private GameObject _light;

        protected override void CreateCallback()
        {
            _components.Add(new TorchlightFire(_isEnabled, _fireSystem, _light, _timerToOn));
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
    }
}