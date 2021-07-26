using Modules.Actors.Runtime;
using UnityEngine;

namespace TEW.Common.Data.Animations
{
    [CreateAssetMenu(fileName = "Animation_Data", menuName = "Data/Animations/Animation")]
    public class AnimationData : ActorData
    {
        public Animator Animator { get; private set; }

        public string MovingAnimationKey => _movingAnimationKey;
        public string AttackAnimationKey => _attackAnimationKey;

        [SerializeField] private string _movingAnimationKey;
        [SerializeField] private string _attackAnimationKey;

        protected override void CreateCallback(IActor owner)
        {
            Animator = owner.GetMonoComponent<Animator>();
        }
    }
}