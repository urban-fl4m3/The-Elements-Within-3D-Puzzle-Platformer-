using Modules.Ticks.Runtime;
using UnityEngine;
using TEW.Common;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraPoint;
    [SerializeField] private float offset;
    public PropertyStateCamera follow;
    
    
    private void Start()
    {
        follow = new PropertyStateCamera(transform, player, cameraPoint, offset);
        TickManager.AddTick(this, follow);
    }
}
