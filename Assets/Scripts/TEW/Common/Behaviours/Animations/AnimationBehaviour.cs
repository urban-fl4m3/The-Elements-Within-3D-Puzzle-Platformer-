using Modules.Actors.Runtime;
using TEW.Common.Data.Animations;
using UnityEngine;

namespace TEW.Common.Behaviours.Animations
{
    [CreateAssetMenu(fileName = "Animation_Behaviour", menuName = "Behaviours/Animations/Animation Switch")]
    public class AnimationBehaviour : ActorBehaviour
    {
        private AnimationData _animationData;
        
        protected override void CreateCallback(IActor owner)
        {
            _animationData = owner.GetData<AnimationData>();
        }

        protected override void ActivateCallback()
        {
            _animationData.Animator.enabled = true;
        }

        protected override void DeactivateCallback()
        {
            _animationData.Animator.enabled = false;
        }

        protected override void DisposeCallback()
        {
                
        }
    }
}