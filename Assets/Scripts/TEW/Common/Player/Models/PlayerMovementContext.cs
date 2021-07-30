using Modules.Common.Runtime;
using UnityEngine;

namespace TEW.Common.Player.Models
{
    public readonly struct PlayerMovementContext
    {
        public readonly CharacterController Controller;
        public readonly IDynamicProperty<bool> IsRunning;
        public readonly float MovementSpeed;
        public readonly float RotationSpeed;
        
        public PlayerMovementContext(CharacterController controller, IDynamicProperty<bool> isRunning,
            float movementSpeed, float rotationSpeed)
        {
            Controller = controller;
            IsRunning = isRunning;
            MovementSpeed = movementSpeed;
            RotationSpeed = rotationSpeed;
        }
    }
}