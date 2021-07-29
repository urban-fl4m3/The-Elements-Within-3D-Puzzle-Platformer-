using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common
{
    public class AnimationHandler: ITickUpdate
    {
        private readonly Animator _animator;
        public DynamicDynamicProperty<bool> isRunning = new DynamicDynamicProperty<bool>(false);
        public DynamicDynamicProperty<bool> isAttack = new DynamicDynamicProperty<bool>(false);
        private float _timer = 10;
        public AnimationHandler(Animator animator)
        {
            _animator = animator;
            isRunning.Changed += Run;
        }

     
        public bool Enabled { get; set; }
        public void Tick()
        {
            if (!isRunning.Value)
                _timer -= Time.deltaTime;
            
            IdlePause();
        }
        
        private void Run(object sender, bool e)
        {
            _animator.SetBool("IsRunning", e);
            _timer = 10;
        }

        private void IdlePause()
        {
            
            if(_timer>0)
                return;
            _animator.SetTrigger("Pause");
            _timer = 10;
        }

    }
}