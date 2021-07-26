// ReSharper disable once CheckNamespace
namespace Modules.Ticks.Runtime
{
    internal static class TickManagerProvider
    {
        private static readonly object _lockObject = new object();
        
        public static TickProcessorProxy GetTickProcessorProxy()
        {
            if (_tickProcessorProxy == null)
            {
                lock (_lockObject)
                {
                    TickBuilder
                        .New()
                        .Build();
                }
            }

            return _tickProcessorProxy;
        }

        private static TickProcessorProxy _tickProcessorProxy; 
            
        public static void Initialize(TickProcessorProxy tickProcessorProxy)
        {
            _tickProcessorProxy = tickProcessorProxy;
        }
    }
}