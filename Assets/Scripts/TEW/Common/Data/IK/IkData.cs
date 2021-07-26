using Modules.Actors.Runtime;
using TEW.Common.Components;
using UnityEngine;

namespace TEW.Common.Data.IK
{
    [CreateAssetMenu(fileName = "IK_Data", menuName = "Data/IK/IK")]
    public class IkData : ActorData
    { 
        public IkAnimationComponent Component { get; private set; }
        
        public float PelvisOffset => _pelvisOffset;
        public LayerMask EnvironmentLayer => _environmentLayer;
        public float FeetToIkPositionSpeed => _feetToIkPositionSpeed;
        
        [SerializeField] private float _pelvisOffset;
        [SerializeField] private LayerMask _environmentLayer;
        [Range(0.0f, 1.0f)] [SerializeField] private float _feetToIkPositionSpeed;

        protected override void CreateCallback(IActor owner)
        {
            Component = owner.GetMonoComponent<IkAnimationComponent>();
        }
    }
}