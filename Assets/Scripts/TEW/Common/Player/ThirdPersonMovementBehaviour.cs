using Modules.Common.Runtime;
using TEW.Common.Player.Models;
using Unity.Mathematics;
using UnityEngine;

namespace TEW.Common.Player
{
    public class ThirdPersonMovementBehaviour : IPlayerMovementBehaviour
    {
        public bool Enabled { get; set; }

        private readonly Transform _camera;
        private Transform _playerRotation;

        private CharacterController _controller;
        private IDynamicProperty<bool> _isRunning;
        private float _movementSpeed;
        private float _rotationSpeed;
        private float _vertical;
        private float _horizontal;

        public ThirdPersonMovementBehaviour(Transform camera, Transform playerRotation)
        {
            _camera = camera;
            _playerRotation = playerRotation;
        }

        public void ApplyContext(PlayerMovementContext context)
        {
            _isRunning = context.IsRunning;
            _controller = context.Controller;
            _movementSpeed = context.MovementSpeed;
            _rotationSpeed = context.RotationSpeed;
        }

        public void Dispose()
        {

        }

        public void Tick()
        {
            _isRunning.Value = !(_horizontal == 0 && _vertical == 0);
            Movement();
            Rotate();
        }

        private void Movement()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            var transform = _controller.transform;
            var direction = (transform).TransformDirection(_horizontal, 0, _vertical);
            var playerSpeed = direction.magnitude * Time.deltaTime * _movementSpeed;

            _controller.Move(transform.forward * playerSpeed + Vector3.down * 9.81f);
        }

        private void Rotate()
        {
            if (!_isRunning.Value)
                return;
            
            
            var movementDirection = new Vector3(_horizontal, 0, _vertical);
            _playerRotation.localRotation = Quaternion.LookRotation(movementDirection);
            
            
            var targetRotate = _playerRotation.forward;
            targetRotate.y = 0;

            var lookDirection = Quaternion.LookRotation(targetRotate);

            _controller.transform.rotation =
                Quaternion.RotateTowards(_controller.transform.rotation, lookDirection,
                    _rotationSpeed * Time.deltaTime);
        }
    }
}