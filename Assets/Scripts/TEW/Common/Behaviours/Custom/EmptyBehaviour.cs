using Modules.Actors.Runtime;
using UnityEngine;

namespace TEW.Common.Behaviours.Custom
{
    [CreateAssetMenu(fileName = "Empty_Behaviour", menuName = "Behaviours/Custom/Empty")]
    public sealed class EmptyBehaviour: ActorBehaviour
    {
        protected override void CreateCallback(IActor owner)
        {
            
        }

        protected override void ActivateCallback()
        {
            
        }

        protected override void DeactivateCallback()
        {
            
        }

        protected override void DisposeCallback()
        {
            
        }
    }
}