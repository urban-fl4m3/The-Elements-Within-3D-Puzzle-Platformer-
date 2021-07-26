using Modules.Actors.Runtime;
using TEW.Common.Components;
using UnityEngine;

namespace TEW.Common.Data.Animations
{
    [CreateAssetMenu(fileName = "AnimationEventHandler_Data", menuName = "Data/Animations/Event Handler")]
    public class AnimationEventHandlerData : ActorData
    {
        public AnimationEventHandler EventHandler { get; private set; }
        
        protected override void CreateCallback(IActor owner)
        {
            EventHandler = owner.GetMonoComponent<AnimationEventHandler>();
        }
    }
}