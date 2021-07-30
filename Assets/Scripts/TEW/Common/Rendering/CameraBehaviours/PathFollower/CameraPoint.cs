using UnityEngine;

namespace TEW.Common.Rendering.CameraBehaviours.PathFollower
{
    public class CameraPoint: MonoBehaviour
    {
        [SerializeField] private bool _lookAtPlayer;
        [SerializeField] private bool _isGetPath;
        [SerializeField] private Vector3 _path;
        [SerializeField] private FixedCamera _fixedCamera;

        public void SetCameraBehaviour()
        {
            var tr = transform;
            _fixedCamera.SetBehaviour(_lookAtPlayer,_isGetPath,tr.position,_path, tr.eulerAngles);
        }
    }
}