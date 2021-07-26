using Modules.Actors.Runtime;
using UnityEngine;

namespace TEW.Common.Data.Transforms
{
    [CreateAssetMenu(fileName = "Rotation_Data", menuName = "Data/Transforms/Rotation")]
    public class RotationData : ActorData
    {
        public bool CanRotate { get; set; }

        [SerializeField] private bool _canRotate;
        
        protected override void CreateCallback(IActor owner)
        {
            CanRotate = _canRotate;
        }
    }
}