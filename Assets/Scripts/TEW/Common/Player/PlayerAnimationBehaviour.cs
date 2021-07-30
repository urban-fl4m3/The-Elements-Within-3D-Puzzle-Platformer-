using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common.Player
{
    public class AnimationHandler : ITickUpdate
    {
        private static readonly int Running = Animator.StringToHash("IsRunning");
        private static readonly int Pause = Animator.StringToHash("Pause");
        
        public bool Enabled { get; set; }
        private readonly IDynamicProperty<bool> _isRunning;
       
        private readonly Animator _animator;
        private float _timer = 10;

        public AnimationHandler(Animator animator, IDynamicProperty<bool> isRunning)
        {
            _animator = animator;
            _isRunning = isRunning;
            _isRunning.Changed += Run;
        }

        public void Tick()
        {
            if (!_isRunning.Value)
            {
                _timer -= Time.deltaTime;
            }

            IdlePause();
        }

        private void Run(object sender, bool e)
        {
            _animator.SetBool(Running, e);
            ResetTimer();
        }

        private void IdlePause()
        {
            if (_timer > 0)
            {
                return;
            }
            
            _animator.SetTrigger(Pause);
            ResetTimer();
        }

        private void ResetTimer()
        {
            _timer = 10;
        }
    }
}