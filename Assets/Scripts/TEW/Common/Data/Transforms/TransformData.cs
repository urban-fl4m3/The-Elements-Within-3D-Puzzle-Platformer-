using Modules.Actors.Runtime;
using UnityEngine;

namespace TEW.Common.Data.Transforms
{
    [CreateAssetMenu(fileName = "Transform_Data", menuName = "Data/Transforms/Transform")]
    public class TransformData : ActorData
    {
        public Transform Transform { get; private set; }
        
        protected override void CreateCallback(IActor owner)
        {
            Transform = owner.GetMonoComponent<Transform>();
        }
    }
}