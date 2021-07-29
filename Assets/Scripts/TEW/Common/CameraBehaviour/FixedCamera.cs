using UnityEngine;

namespace TEW.Common
{
    public class FixedCamera: MonoBehaviour
    {
        public Transform player;
        public Vector3 cameraRotation;
        public Vector3 startPosition;
        public Vector3 endPosition;
        public bool isLookAtPlayer;
        public bool isFlyCamera;
        public UnityEngine.Camera camera;
        void Update()
        {
            RotateCamera();
            MoveCamera();
        }

        private void MoveCamera()
        {
            if (!isFlyCamera)
                camera.transform.position = startPosition;
            else
            {
                
            }
        }

        private void RotateCamera()
        {
            if (!isLookAtPlayer)
                camera.transform.eulerAngles = cameraRotation;
            else
                camera.transform.LookAt(player);
        }

        
        public void SetBehaviour(bool isLookAt, bool isFly, Vector3 startPos, Vector3 endPos, Vector3 rotation)
        {
            CleanState();
            isLookAtPlayer = isLookAt;
            isFlyCamera = isFly;
            startPosition = startPos;
            endPosition = endPos;
            cameraRotation = rotation;
        }

        private void CleanState()
        {
            cameraRotation=Vector3.zero;
            startPosition = Vector3.zero;
            endPosition = Vector3.zero;
            isLookAtPlayer = false;
            isFlyCamera = false;
        }
    }
}