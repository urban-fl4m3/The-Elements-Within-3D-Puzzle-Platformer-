using UnityEngine;

namespace TEW.Common.CameraBehaviour
{
    public class FixedCamera: MonoBehaviour
    {
        [SerializeField] private Transform player;
        private Vector3 _cameraRotation;
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private bool _isLookAtPlayer;
        private bool _isFlyCamera;
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }
        void Update()
        {
            RotateCamera();
            MoveCamera();
        }
        private void MoveCamera()
        {
            if (!_isFlyCamera)
                _camera.transform.position = _startPosition;
            else
            {
                
            }
        }
        private void RotateCamera()
        {
            if (!_isLookAtPlayer)
                _camera.transform.eulerAngles = _cameraRotation;
            else
                _camera.transform.LookAt(player);
        }
        public void SetBehaviour(bool isLookAt, bool isFly, Vector3 startPos, Vector3 endPos, Vector3 rotation)
        {
            CleanState();
            _isLookAtPlayer = isLookAt;
            _isFlyCamera = isFly;
            _startPosition = startPos;
            _endPosition = endPos;
            _cameraRotation = rotation;
        }
        private void CleanState()
        {
            _cameraRotation=Vector3.zero;
            _startPosition = Vector3.zero;
            _endPosition = Vector3.zero;
            _isLookAtPlayer = false;
            _isFlyCamera = false;
        }
    }
}