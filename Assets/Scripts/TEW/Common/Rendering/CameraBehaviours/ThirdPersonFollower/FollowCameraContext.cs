using UnityEngine;

namespace TEW.Common.Rendering.CameraBehaviours.ThirdPersonFollower
{
    public readonly struct FollowCameraContext
    {
        public readonly Vector3 Offset;
        public readonly float VerticalMinLimit;
        public readonly float VerticalMaxLimit;
        public readonly float MouseSpeed;
        
        public FollowCameraContext(Vector3 offset, float verticalMinLimit, float verticalMaxLimit, float mouseSpeed)
        {
            Offset = offset;
            VerticalMinLimit = verticalMinLimit;
            VerticalMaxLimit = verticalMaxLimit;
            MouseSpeed = mouseSpeed;
        }
    }
}