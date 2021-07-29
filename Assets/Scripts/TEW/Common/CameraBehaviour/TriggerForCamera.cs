using UnityEngine;

namespace TEW.Common.CameraBehaviour
{
    public class TriggerForCamera: MonoBehaviour
    {
        [SerializeField] private CameraPoint cameraPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                cameraPoint.SetCameraBehaviour();
            }
        }
    }
}