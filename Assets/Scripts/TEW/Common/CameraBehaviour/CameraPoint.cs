using UnityEngine;

namespace TEW.Common.Camera
{
    public class CameraPoint: MonoBehaviour
    {
        [SerializeField] private bool lookAtPlayer;
        [SerializeField] private bool isGetPath;
        [SerializeField] private Vector3 path;
        public FixedCamera fixedCamera;

        public void SetCameraBehaivor()
        {
            fixedCamera.SetBehaviour(lookAtPlayer,isGetPath,transform.position,path, transform.eulerAngles);
        }
    }
}