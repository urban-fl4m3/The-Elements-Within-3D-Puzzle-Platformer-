using UnityEngine;

namespace TEW.Common.Rendering.CameraBehaviours.PathFollower
{
    public class TriggerForCamera: MonoBehaviour
    {
        [SerializeField] private CameraPoint _cameraPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _cameraPoint.SetCameraBehaviour();
            }
        }
    }
}