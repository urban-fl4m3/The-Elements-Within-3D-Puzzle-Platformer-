using Modules.Actors.Runtime;
using TEW.Common.Behaviours.Ticks;
using TEW.Common.Data.Custom;
using TEW.Common.Data.Transforms;
using UnityEngine;

namespace TEW.Common.Behaviours.Transforms
{
    [CreateAssetMenu(fileName = "SubjectFollower_Behaviour", menuName = "Behaviours/Transforms/Subject follower")]
    public class SubjectFollowerBehaviour : TickLateBehaviour
    {
        private TransformData _transformData;
        private ActorSubjectData _subjectData;
        private TransformData _subjectTransformData;

        protected override void CreateCallback(IActor owner)
        {
            _transformData = owner.GetData<TransformData>();
            _subjectData = owner.GetData<ActorSubjectData>();
            
            _subjectData.Subject.Changed += SubjectOnChanged;
        }

        private void SubjectOnChanged(object sender, IActor e)
        {
            if (e == null)
            {   
                Deactivate();
            }
            else
            {
                _subjectTransformData = e.GetData<TransformData>();
            
                Activate();
            }
        }
        
        protected override void TickCallback()
        {
            var position = _transformData.Transform.position;
            var subjectPosition = _subjectTransformData.Transform.position;

            position = Vector3.Slerp(position, subjectPosition, 0.01f);
            _transformData.Transform.position = position;
        }
    }
}