using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common.CameraBehaviour
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 cameraPoint;
        [SerializeField] private float offset;
        [SerializeField] private Vector2 cameraLimY;
        private PropertyStateCamera _follow;
    
    
        private void Start()
        {
            _follow = new PropertyStateCamera(transform, player, cameraPoint, offset, cameraLimY);
            TickManager.AddTick(this, _follow);
        }
    }
}
