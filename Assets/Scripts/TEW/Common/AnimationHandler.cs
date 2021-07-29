using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common
{
    public class AnimationHandler: ITickUpdate
    {
        public bool Enabled { get; set; }
        public readonly DynamicDynamicProperty<bool> IsRunning = new DynamicDynamicProperty<bool>(false);
        private static readonly int Running = Animator.StringToHash("IsRunning");
        private static readonly int Pause = Animator.StringToHash("Pause");
        private readonly Animator _animator;
        private float _timer = 10;

        public AnimationHandler(Animator animator)
        {
            _animator = animator;
            IsRunning.Changed += Run;
        }
        public void Tick()
        {
            if (!IsRunning.Value)
                _timer -= Time.deltaTime;
            
            IdlePause();
        }
        private void Run(object sender, bool e)
        {
            _animator.SetBool(Running, e);
            ResetTimer();
        }
        private void IdlePause()
        {
            
            if(_timer>0)
                return;
            _animator.SetTrigger(Pause);
            ResetTimer();
        }
        private void ResetTimer()
        {
            _timer = 10;
        }
    }
}