using Cinemachine;
using TEW.Common.Player;
using UnityEngine;

namespace TEW.Common.Rendering.CameraBehaviours.ThirdPersonFollower
{
    public class ThirdPersonCamera : CameraActor
    {
        [SerializeField] private Transform _follow;
        [SerializeField] private Transform _lookAtTransform;
        [SerializeField] private CinemachineVirtualCameraBase _cinemachine;
        
        protected override void ActivateCallback()
        {
            _cinemachine.Follow = _follow;
            _cinemachine.LookAt = _lookAtTransform;
        }

        protected override void DeactivateCallback()
        {
            
        }

        public override IPlayerMovementBehaviour GetMovementBehaviour()
        {
            return new ThirdPersonMovementBehaviour(transform, _cinemachine.transform);
        }
    }
}
