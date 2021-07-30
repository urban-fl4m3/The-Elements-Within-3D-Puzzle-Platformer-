namespace TEW.Common.Rendering
{
    public interface IActiveCamera : IMovementBehaviourProvider
    {
        void Activate();
        void Deactivate();
    }
}