using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Modules.Ticks.Runtime
{
    internal class TickProcessorProxy
    {
        private readonly Dictionary<object, List<ITick>> _allTicks = new Dictionary<object, List<ITick>>();
        
        private readonly TickProcessor _processor;

        public TickProcessorProxy(TickProcessor processor)
        {
            _processor = processor;
        }
        
        public void AddTick(object owner, ITickUpdate tick)
        {
            AddTickInternal(owner, tick);
            _processor.TickUpdates.Add(tick);
        }

        public void AddTick(object owner, ITickLateUpdate tick)
        {
            AddTickInternal(owner, tick);
            _processor.TickLateUpdates.Add(tick);
        }

        public void AddTick(object owner, ITickFixedUpdate tick)
        {
            AddTickInternal(owner, tick);
            _processor.TickFixedUpdates.Add(tick);
        }

        public void RemoveTick(ITickUpdate tick)
        {
            tick.Enabled = false;
            _processor.TickUpdates.Remove(tick);
        }

        public void RemoveTick(ITickLateUpdate tick)
        {
            tick.Enabled = false;
            _processor.TickLateUpdates.Remove(tick);
        }

        public void RemoveTick(ITickFixedUpdate tick)
        {
            tick.Enabled = false;
            _processor.TickFixedUpdates.Remove(tick);
        }
        
        private void AddTickInternal(object owner, ITick tick)
        {
            var hasOwner = _allTicks.TryGetValue(owner, out var tickList);

            if (hasOwner)
            {
                tickList.Add(tick);
            }
            else
            {
                tickList = new List<ITick> {tick};
                _allTicks.Add(owner, tickList);
            }
            
            tick.Enabled = true;
        }
    }
}