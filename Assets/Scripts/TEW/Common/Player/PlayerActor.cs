using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using TEW.Common.Player.Models;
using UnityEngine;

namespace TEW.Common.Player
{
    public class PlayerActor : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        
        private AnimationHandler _animationHandler;
        private PlayerMovementContext _context;

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

        private IPlayerMovementBehaviour _movementBehaviour;

        private readonly IDynamicProperty<bool> _isRunning = new DynamicProperty<bool>();
        
        private void Start()
        {
            _animationHandler = new AnimationHandler(_animator, _isRunning);
          
            TickManager.AddTick(this,_animationHandler);
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
    }
}
