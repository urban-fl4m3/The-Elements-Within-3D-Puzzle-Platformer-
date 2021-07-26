using System.Collections;
using UnityEngine;

namespace Modules.Coroutines.Runtime.Scripts
{
    internal class CoroutineProcessor : ICoroutineProcessor
    {
        private readonly CoroutineObject _object;

        public CoroutineProcessor(CoroutineObject coroutineObject)
        {
            _object = coroutineObject;
        }

        public Coroutine StartCoroutine(IEnumerator process)
        {
            return _object.StartCoroutine(process);
        }

        public void StopCoroutine(Coroutine process)
        {
            _object.StopCoroutine(process);
        }
    }
}