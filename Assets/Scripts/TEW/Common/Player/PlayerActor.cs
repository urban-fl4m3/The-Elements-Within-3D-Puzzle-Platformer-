using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using TEW.Common.Player.Interactions;
using TEW.Common.Player.Models;
using TEW.Common.World.Interactive;
using UnityEngine;

namespace TEW.Common.Player
{
    public class PlayerActor : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private LayerMask _interactionMask;
        
        private AnimationHandler _animationHandler;
        private InteractionInputBehaviour _interactionInputBehaviour;
        private InteractiveObjectRaycastBehaviour _interactiveObjectRaycastBehaviour;
        
        private PlayerMovementContext _context;
        private IPlayerMovementBehaviour _movementBehaviour;
        private readonly IDynamicProperty<bool> _isRunning = new DynamicProperty<bool>();

        public IPlayerMovementBehaviour MovementBehaviour
        {
            get => _movementBehaviour;
            set
            {
                if (_movementBehaviour != null)
                {
                    _movementBehaviour.Dispose();
                    TickManager.RemoveTick(_movementBehaviour);
                }

                _movementBehaviour = value;
                _movementBehaviour.ApplyContext(GetContext());
                TickManager.AddTick(this, _movementBehaviour);
            }
        }

        private void Start()
        {
            var interactiveObject = new DynamicProperty<IInteractable>();

            _interactiveObjectRaycastBehaviour =
                new InteractiveObjectRaycastBehaviour(transform, _interactionMask, 1, interactiveObject);
            _interactionInputBehaviour = new InteractionInputBehaviour(interactiveObject);
            _animationHandler = new AnimationHandler(_animator, _isRunning);
            
            TickManager.AddTick(this, _animationHandler);
            TickManager.AddTick(this, _interactiveObjectRaycastBehaviour);
            TickManager.AddTick(this, _interactionInputBehaviour);
        }

        private ref PlayerMovementContext GetContext()
        {
            _context = new PlayerMovementContext(
                _characterController, 
                _isRunning, 
                _movementSpeed,
                _rotationSpeed);
            
            return ref _context;
        }

        private void OnDestroy()
        {
            _interactionInputBehaviour.Dispose();
        }
    }
}
