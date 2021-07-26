using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Modules.Ticks.Runtime
{
    public class TickBuilder
    {
        private TickBuilder()
        {
            
        }

        public static TickBuilder New()
        {
            return new TickBuilder();
        }

        public void Build()
        {
            var processor = new GameObject("_Tick_Processor").AddComponent<TickProcessor>();
            var tickProcessorProxy = new TickProcessorProxy(processor);
            
            Object.DontDestroyOnLoad(processor);
            
            TickManagerProvider.Initialize(tickProcessorProxy);
        }
    }
}