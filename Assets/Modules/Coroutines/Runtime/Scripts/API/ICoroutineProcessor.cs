using System.Collections;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Modules.Coroutines.Runtime
{
    public interface ICoroutineProcessor
    {
        Coroutine StartCoroutine(IEnumerator process);
        void StopCoroutine(Coroutine process);
    }
}