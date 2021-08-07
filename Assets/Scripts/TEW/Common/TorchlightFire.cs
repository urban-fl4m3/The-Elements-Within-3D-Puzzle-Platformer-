using Modules.Common.Runtime;
using TEW.Common.Components;
using TEW.Common.World.Interactive;
using UnityEngine;

namespace TEW.Common
{
    public class TorchlightFire : IMechanismComponent
    {
        private readonly IReadonlyDynamicProperty<bool> _state;
        private readonly ParticleSystem _fire;

        public TorchlightFire(IReadonlyDynamicProperty<bool> state, ParticleSystem fire)
        {
            _state = state;
            _fire = fire;
        
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

        private void TurnOn(bool enableParticle)
        {
            _fire.gameObject.SetActive(enableParticle);
        }
    }
}