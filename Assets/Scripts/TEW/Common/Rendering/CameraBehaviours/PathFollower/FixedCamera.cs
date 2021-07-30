using UnityEngine;

namespace TEW.Common.Rendering.CameraBehaviours.PathFollower
{
    public class FixedCamera : MonoBehaviour
    {
        [SerializeField] private Transform _player;

        private Vector3 _cameraRotation;
        private Vector3 _startPosition;
        private bool _isLookAtPlayer;
        private bool _isFlyCamera;
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            RotateCamera();
            MoveCamera();
        }

        private void MoveCamera()
        {
            if (!_isFlyCamera)
            {
                _camera.transform.position = _startPosition;
            }
        }

        private void RotateCamera()
        {
            if (!_isLookAtPlayer)
            {
                _camera.transform.eulerAngles = _cameraRotation;
            }
            else
            {
                _camera.transform.LookAt(_player);
            }
        }

        public void SetBehaviour(bool isLookAt, bool isFly, Vector3 startPos, Vector3 endPos, Vector3 rotation)
        {
            CleanState();
            _isLookAtPlayer = isLookAt;
            _isFlyCamera = isFly;
            _startPosition = startPos;
            _cameraRotation = rotation;
        }

        private void CleanState()
        {
            _cameraRotation = Vector3.zero;
            _startPosition = Vector3.zero;
            _isLookAtPlayer = false;
            _isFlyCamera = false;
        }
    }
}