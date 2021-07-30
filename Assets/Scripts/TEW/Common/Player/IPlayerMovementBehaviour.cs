using System;
using Modules.Ticks.Runtime;
using TEW.Common.Player.Models;

namespace TEW.Common.Player
{
    public interface IPlayerMovementBehaviour : ITickFixedUpdate, IDisposable
    {
        void ApplyContext(PlayerMovementContext context);
    }
}