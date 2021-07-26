// ReSharper disable once CheckNamespace
namespace Modules.Coroutines.Runtime
{
    internal static class CoroutineProcessorProvider
    {
        private static readonly object _lockObject = new object();
        
        public static ICoroutineProcessor GetCoroutineProcessor()
        {
            if (_coroutineProcessor == null)
            {
                lock (_lockObject)
                {
                    CoroutineBuilder
                        .New()
                        .Build();
                }
            }

            return _coroutineProcessor;
        }

        private static ICoroutineProcessor _coroutineProcessor;

        public static void Initialize(ICoroutineProcessor coroutineProcessor)
        {
            _coroutineProcessor = coroutineProcessor;
        }
    }
}