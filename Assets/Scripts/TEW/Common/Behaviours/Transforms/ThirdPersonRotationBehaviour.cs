using Modules.Actors.Runtime;
using TEW.Common.Behaviours.Ticks;
using TEW.Common.Data.Custom;
using TEW.Common.Data.Transforms;
using UnityEngine;

namespace TEW.Common.Behaviours.Transforms
{
    [CreateAssetMenu(fileName = "ThirdPersonRotation_Behaviour", menuName = "Behaviours/Transforms/Third Person Rotation Behaviour")]
    public class ThirdPersonRotationBehaviour : TickBehaviour
    {
        private TransformData _transformData;
        private ActorSubjectData _subjectData;
        private RotationData _subjectRotationData;
        private TransformData _subjectTransformData;
        
        protected override void CreateCallback(IActor owner)
        {
            _transformData = owner.GetData<TransformData>();
            _subjectData = owner.GetData<ActorSubjectData>();
        }

        protected override void ActivateCallback()
        {
            base.ActivateCallback();
            
            _subjectData.Subject.Changed += SubjectOnChanged;
        }

        protected override void DisposeCallback()
        {
            base.DisposeCallback();
            
            _subjectData.Subject.Changed -= SubjectOnChanged;
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
                _subjectRotationData = e.GetData<RotationData>();
            
                Activate();
            }
        }

        protected override void TickCallback()
        {
            if (_subjectRotationData.CanRotate) ApplyRotation();
        }

        private void ApplyRotation()
        {
            var actorTransformForward = _subjectTransformData.Transform.forward;
            actorTransformForward.Scale(new Vector3(1.0f, 0.0f, 1.0f));
            actorTransformForward.Normalize();

            var cameraForward = _transformData.Transform.forward;
            cameraForward.Scale(new Vector3(1.0f, 0.0f, 1.0f));
            cameraForward.Normalize();

            var inCameraRotation = Vector3.SignedAngle(actorTransformForward, cameraForward, Vector3.up);
           
            var newRotation = _transformData.Transform.rotation;
            newRotation = Quaternion.Slerp(newRotation,
                newRotation * Quaternion.Euler(0.0f, inCameraRotation, 0.0f), 0.1f);

            _subjectTransformData.Transform.rotation = newRotation;
        }
    }
}