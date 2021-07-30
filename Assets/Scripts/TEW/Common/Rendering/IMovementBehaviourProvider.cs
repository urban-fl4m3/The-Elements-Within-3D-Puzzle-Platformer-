using TEW.Common.Player;

namespace TEW.Common.Rendering
{
    public interface IMovementBehaviourProvider
    {
        IPlayerMovementBehaviour GetMovementBehaviour();
    }
}