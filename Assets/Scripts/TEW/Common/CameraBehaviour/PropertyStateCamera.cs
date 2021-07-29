using Modules.Ticks.Runtime;
using Unity.Mathematics;
using UnityEngine;

namespace TEW.Common.CameraBehaviour
{
    public class PropertyStateCamera: ITickLateUpdate
    {
        public bool Enabled { get; set; }
        
        private readonly Transform _camera;
        private readonly Transform _target;
        private readonly Vector3 _point;
        private readonly GameObject _center;
        private readonly Vector2 _limitY;
        private float _offset;
        private float _angleX = 0;
        private float _angleY = 0;
       
        public PropertyStateCamera(Transform camera, Transform target, Vector3 point, float offset, Vector2 limitY)
        {
            _camera = camera;
            _target = target;
            _point = point;
            _offset = offset;
            _limitY = limitY;
            
            _center = new GameObject();
            _center.transform.position = point;
            camera.SetParent(_center.transform);
            camera.transform.localPosition=-Vector3.forward*offset;
        }

        public void Tick()
        {
           ChangePosition();
           ChangeRotation();
           CheckCameraBarrier();
        }
        private void ChangePosition()
        {
            var cameraOffsetX=_camera.transform.right*_point.x;
            _center.transform.position = _target.position + Vector3.up*_point.y + cameraOffsetX;
        }
        private void ChangeRotation()
        {
            _angleX += Input.GetAxis("Mouse X");
            _angleY -= Input.GetAxis("Mouse Y");

            _angleY = Mathf.Clamp(_angleY, _limitY.x, _limitY.y);

            _center.transform.rotation = quaternion.Euler(_angleY, _angleX, 0);
        }

        private void CheckCameraBarrier()
        {
            
        }

    }
}