// ReSharper disable once CheckNamespace
namespace Modules.Ticks.Runtime
{
    public static class TickManager
    {
        public static void AddTick(object owner, ITickUpdate tick)
        {
            TickManagerProvider.GetTickProcessorProxy().AddTick(owner, tick);
        }
        
        public static void AddTick(object owner, ITickLateUpdate tick)
        {
            TickManagerProvider.GetTickProcessorProxy().AddTick(owner, tick);
        }

        public static void AddTick(object owner, ITickFixedUpdate tick)
        {
            TickManagerProvider.GetTickProcessorProxy().AddTick(owner, tick);
        }

        public static void RemoveTick(ITickUpdate tick)
        {
            TickManagerProvider.GetTickProcessorProxy().RemoveTick(tick);
        }

        public static void RemoveTick(ITickLateUpdate tick)
        {
            TickManagerProvider.GetTickProcessorProxy().RemoveTick(tick);
        }

        public static void RemoveTick(ITickFixedUpdate tick)
        {
            TickManagerProvider.GetTickProcessorProxy().RemoveTick(tick);
        }
    }
}