using TEW.Common.Player;
using UnityEngine;

namespace TEW.Common.Rendering
{
    public abstract class CameraActor : MonoBehaviour, IActiveCamera
    {
        public void Activate()
        {
            ActivateCallback();
        }

        public void Deactivate()
        {
            DeactivateCallback();
        }

        protected abstract void ActivateCallback();
        protected abstract void DeactivateCallback();

        public abstract IPlayerMovementBehaviour GetMovementBehaviour();
    }
}