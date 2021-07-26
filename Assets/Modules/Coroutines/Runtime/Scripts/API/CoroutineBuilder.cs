using Modules.Coroutines.Runtime.Scripts;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Modules.Coroutines.Runtime
{
    public class CoroutineBuilder
    {
        private CoroutineBuilder()
        {
            
        }

        public static CoroutineBuilder New()
        {
            return new CoroutineBuilder();
        }

        public void Build()
        {
            var coroutineObject = new GameObject(nameof(CoroutineProcessor)).AddComponent<CoroutineObject>();
            var coroutineProcessor = new CoroutineProcessor(coroutineObject);
            Object.DontDestroyOnLoad(coroutineObject);
            
            CoroutineProcessorProvider.Initialize(coroutineProcessor);
        }
    }
}