using UnityEngine;

namespace TEW.Common.CameraBehaviour
{
    public class CameraPoint: MonoBehaviour
    {
        [SerializeField] private bool lookAtPlayer;
        [SerializeField] private bool isGetPath;
        [SerializeField] private Vector3 path;
        public FixedCamera fixedCamera;

        public void SetCameraBehaviour()
        {
            fixedCamera.SetBehaviour(lookAtPlayer,isGetPath,transform.position,path, transform.eulerAngles);
        }
    }
}