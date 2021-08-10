using Cinemachine;
using TEW.Common.Player;
using TEW.Common.Rendering;
using UnityEngine;

namespace System
{
    public class FixedCamera: CameraActor
    {
        [SerializeField] private Transform _lookAtTransform;
        [SerializeField] private CinemachineVirtualCameraBase _cinemachine;
        [SerializeField] private Transform _playerFixedRotation;
        protected override void ActivateCallback()
        {
            _cinemachine.LookAt = _lookAtTransform;
        }

        protected override void DeactivateCallback()
        {
            Debug.Log("CameraDeactivate");
        }

        public override IPlayerMovementBehaviour GetMovementBehaviour()
        {
            return new ThirdPersonMovementBehaviour(transform, _playerFixedRotation);
        }
    }
}