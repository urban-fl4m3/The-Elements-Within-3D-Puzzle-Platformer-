using Modules.Actors.Runtime;
using Modules.Ticks.Runtime;

namespace TEW.Common.Behaviours.Ticks
{
    public abstract class TickBehaviour : ActorBehaviour, ITickUpdate
    {
        public bool Enabled { get; set; }
        
        protected override void CreateCallback(IActor owner)
        {
            TickManager.AddTick(owner, this);;
        }
        
        protected override void ActivateCallback()
        {
            Enabled = true;
        }

        protected override void DeactivateCallback()
        {
            Enabled = false;
        }

        protected override void DisposeCallback()
        {
            TickManager.RemoveTick(this);
        }
        
        public void Tick()
        {
            if (Enabled)
            {
                TickCallback();
            }
        }

        protected abstract void TickCallback();
    }
}