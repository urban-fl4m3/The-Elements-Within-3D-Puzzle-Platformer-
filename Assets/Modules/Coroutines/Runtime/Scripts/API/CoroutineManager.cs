using System.Collections;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Modules.Coroutines.Runtime
{
    public static class CoroutineManager
    {
        public static Coroutine StartCoroutine(IEnumerator process)
        {
            return CoroutineProcessorProvider.GetCoroutineProcessor().StartCoroutine(process);
        }

        public static void StopCoroutine(Coroutine process)
        {
            CoroutineProcessorProvider.GetCoroutineProcessor().StopCoroutine(process);
        }
    }
}