using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common.Rendering.CameraBehaviours.ThirdPersonFollower
{
    public class ThirdPersonCameraBehaviour : ITickLateUpdate
    {
        public bool Enabled { get; set; }

        private readonly Transform _camera;
        private readonly Transform _target;
        private readonly Vector3 _offset;
        private readonly GameObject _holder;
        private readonly Vector2 _verticalRotationEdges;
        private readonly float _mouseSpeed;
        
        private float _xRotation;
        private float _yRotation;

        public ThirdPersonCameraBehaviour(Transform camera, Transform target, FollowCameraContext context)
        {
            _camera = camera;
            _target = target;
            _offset = context.Offset;
            _mouseSpeed = context.MouseSpeed;
            _verticalRotationEdges = new Vector2(context.VerticalMinLimit, context.VerticalMaxLimit);
            
            _holder = CreateCameraHolder();
        }

        public void Tick()
        {
            ChangePosition();
            ChangeRotation();
        }

        private void ChangePosition()
        {
            var cameraOffsetX = _camera.transform.right * _offset.x;
            _holder.transform.position = _target.position + Vector3.up * _offset.y + cameraOffsetX;
        }

        private void ChangeRotation()
        {
            _xRotation += Input.GetAxis("Mouse X") * _mouseSpeed;
            _yRotation -= Input.GetAxis("Mouse Y") * _mouseSpeed;

            _yRotation = Mathf.Clamp(_yRotation, _verticalRotationEdges.x, _verticalRotationEdges.y);
            _holder.transform.rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
        }

        private GameObject CreateCameraHolder()
        {
            var holder = new GameObject
            {
                transform =
                {
                    position = _offset
                }
            };
            
            _camera.SetParent(holder.transform);
            _camera.transform.localPosition = -Vector3.forward * 2;
            
            return holder;
        }
    }
}