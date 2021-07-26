using Modules.Actors.Runtime;
using Modules.Common.Runtime;
using UnityEngine;

namespace TEW.Common.Data.Custom
{
    [CreateAssetMenu(fileName = "Subject_Data", menuName = "Data/Custom/Subject")]
    public class ActorSubjectData : ActorData
    {
        public IDynamicProperty<IActor> Subject { get; private set; }
        
        protected override void CreateCallback(IActor owner)
        {
            Subject = new DynamicDynamicProperty<IActor>(owner);
        }
    }
}