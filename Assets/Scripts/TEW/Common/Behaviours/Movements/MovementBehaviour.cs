using Modules.Actors.Runtime;
using TEW.Common.Behaviours.Ticks;
using TEW.Common.Data.Animations;
using TEW.Common.Data.Bindings;
using TEW.Common.Data.Movement;
using UnityEngine;

namespace TEW.Common.Behaviours.Movements
{
    [CreateAssetMenu(fileName = "Movement_Behaviour", menuName = "Behaviours/Movements/Movement")]
    public class MovementBehaviour: TickBehaviour
    {
        private Animator _animator;

        private AnimationData _animationData;
        private MovementData _movementData;
        private KeyBindingsData _bindingData;

        private string _horizontalKeyAxis;
        private string _verticalKeyAxis;
        
        protected override void CreateCallback(IActor owner)
        {
            _animationData = owner.GetData<AnimationData>();
            _movementData = owner.GetData<MovementData>();
            _bindingData = owner.GetData<KeyBindingsData>();

            _animator = _animationData.Animator;
            _horizontalKeyAxis = _bindingData.HorizontalKeyAxis;
            _verticalKeyAxis = _bindingData.VerticalKeyAxis;
        }
        
        protected override void TickCallback()
        {
            var horizontalMovement = Input.GetAxis(_horizontalKeyAxis);
            var verticalMovement = Input.GetAxis(_verticalKeyAxis);
            
            var isMoving = !Mathf.Approximately(horizontalMovement, 0) 
                           || !Mathf.Approximately(verticalMovement, 0);
            
            _movementData.IsMoving = isMoving;
            
            _animator.SetBool(_animationData.MovingAnimationKey, isMoving);
            _animator.SetFloat(_horizontalKeyAxis, horizontalMovement);
            _animator.SetFloat(_verticalKeyAxis, verticalMovement);
        }
    }
}