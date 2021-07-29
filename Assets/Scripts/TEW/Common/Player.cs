using Modules.Ticks.Runtime;
using TEW.Common.CameraBehaviour;
using UnityEngine;

namespace TEW.Common
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private CameraFollow cameraFollow;
        [SerializeField] private Animator animator;
        [SerializeField] private float runSpeed;
        [SerializeField] private float rotationSpeed;
        private MovementActor _movementActor;
        private CharacterController _characterController;
        private AnimationHandler _animationHandler;
    
        private void Start()
        {
            _animationHandler = new AnimationHandler(animator);
            _characterController = GetComponent<CharacterController>();
            _movementActor = new MovementActor(_characterController, runSpeed, rotationSpeed, cameraFollow, _animationHandler.IsRunning);
            TickManager.AddTick(this,_movementActor);
            TickManager.AddTick(this,_animationHandler);
        }

    }
}
