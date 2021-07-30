using Modules.Common.Runtime;
using TEW.Common.Player.Models;
using UnityEngine;

namespace TEW.Common.Player
{
    public class ThirdPersonMovementBehaviour : IPlayerMovementBehaviour
    {
        public bool Enabled { get; set; }

        private readonly Transform _camera;

        private CharacterController _controller;
        private IDynamicProperty<bool> _isRunning;
        private float _movementSpeed;
        private float _rotationSpeed;
        private float _vertical;
        private float _horizontal;

        public ThirdPersonMovementBehaviour(Transform camera)
        {
            _camera = camera;
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

            var direction = _controller.transform.TransformDirection(_horizontal, 0, _vertical);
            direction *= Time.deltaTime * _movementSpeed;

            _controller.Move(direction);
        }

        private void Rotate()
        {
            if (!_isRunning.Value)
                return;

            var targetRotate = _camera.forward;
            targetRotate.y = 0;

            var lookDirection = Quaternion.LookRotation(targetRotate);

            _controller.transform.rotation =
                Quaternion.RotateTowards(_controller.transform.rotation, lookDirection,
                    _rotationSpeed * Time.deltaTime);
        }
    }
}