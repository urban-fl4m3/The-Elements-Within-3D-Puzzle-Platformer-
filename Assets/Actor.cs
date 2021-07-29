using Modules.Ticks.Runtime;
using TEW.Common;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Actor : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Animator animator;
    private MovementActor _movementActor;
    private CharacterController _characterController;
    private AnimationHandler _animationHandler;
    
    private void Start()
    {
        _animationHandler = new AnimationHandler(animator);
        _characterController = GetComponent<CharacterController>();
        _movementActor = new MovementActor(_characterController, 2, cameraFollow, _animationHandler.isRunning);
        TickManager.AddTick(this,_movementActor);
        TickManager.AddTick(this,_animationHandler);
    }

}
