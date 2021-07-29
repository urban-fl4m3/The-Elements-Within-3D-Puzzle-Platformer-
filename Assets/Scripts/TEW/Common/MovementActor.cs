using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using TEW.Common.CameraBehaviour;
using Unity.Mathematics;
using UnityEngine;

namespace TEW.Common
{
    public class MovementActor: ITickFixedUpdate
    {
        public bool Enabled { get; set; }
        private readonly CharacterController _actor;
        private readonly CameraFollow _cameraFollow;
        private readonly DynamicDynamicProperty<bool> _isRunning;
        private readonly float _speed;
        private readonly float _rotationSpeed;
        private float _vertical;
        private float _horizontal;

        public MovementActor(CharacterController actor, float speed, float rotationSpeed, CameraFollow cameraFollow, DynamicDynamicProperty<bool> isRunning)
        {
            _actor = actor;
            _speed = speed;
            _cameraFollow = cameraFollow;
            _isRunning = isRunning;
            _rotationSpeed = rotationSpeed;
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
            
            var direction = _actor.transform.TransformDirection(_horizontal, 0, _vertical);
            direction *= Time.deltaTime * _speed;
            
            _actor.Move(direction);
        }
        private void Rotate()
        {
            if(!_isRunning.Value)
                return;
            
            var targetRotate = _cameraFollow.transform.forward;
            targetRotate.y = 0;

            var lookDirection = Quaternion.LookRotation(targetRotate);
            
            _actor.transform.rotation =
                Quaternion.RotateTowards(_actor.transform.rotation, lookDirection, _rotationSpeed * Time.deltaTime);
        }
    }
    
}