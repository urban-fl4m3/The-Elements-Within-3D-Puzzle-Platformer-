using System.Threading.Tasks;
using Modules.Common.Runtime;
using TEW.Common.Components;
using UnityEngine;

namespace TEW.Common
{
    public class TorchlightFire : IMechanismComponent
    {
        private readonly IReadonlyDynamicProperty<bool> _state;
        private readonly ParticleSystem _fire;
        private readonly float _timeToWait;
        private readonly GameObject _light;

        public TorchlightFire(IReadonlyDynamicProperty<bool> state, ParticleSystem fire, GameObject light, float timeToWait)
        {
            _state = state;
            _fire = fire;
            _light = light;
            _timeToWait = timeToWait;

            WaitSomeTimeToOn(_state.Value);
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
            WaitSomeTimeToOn(e);
        }

        private async void WaitSomeTimeToOn(bool toDo)
        {
            var a = (int) (_timeToWait * 1000f);
            await Task.Delay(a);
            
            _light.SetActive(toDo);
            _state.Value = toDo;
            
            if (toDo)
                _fire.Play();
            else
                _fire.Stop();
        }
    }
}