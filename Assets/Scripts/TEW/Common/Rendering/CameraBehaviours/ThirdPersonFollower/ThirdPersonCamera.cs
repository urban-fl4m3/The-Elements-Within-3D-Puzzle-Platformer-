using Modules.Ticks.Runtime;
using TEW.Common.Player;
using UnityEngine;

namespace TEW.Common.Rendering.CameraBehaviours.ThirdPersonFollower
{
    public class ThirdPersonCamera : CameraActor
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Vector2 _cameraLimY;
        [SerializeField] private float _mouseSpeed;
        
        private ThirdPersonCameraBehaviour _behaviour;
        
        private void Awake()
        {
            var stateCameraContext = new FollowCameraContext(
                _offset,
                _cameraLimY.x,
                _cameraLimY.y,
                _mouseSpeed
            );

            _behaviour = new ThirdPersonCameraBehaviour(transform, _player, stateCameraContext);
        }

        protected override void ActivateCallback()
        {
            TickManager.AddTick(this, _behaviour);
        }

        protected override void DeactivateCallback()
        {
            TickManager.RemoveTick(_behaviour);
        }

        public override IPlayerMovementBehaviour GetMovementBehaviour()
        {
            return new ThirdPersonMovementBehaviour(transform);
        }
    }
}
