using System;
using System.Collections.Generic;
using UnityEngine;

namespace TEW.Common.Components
{
   public class AnimationEventHandler :MonoBehaviour
    {
        private readonly Dictionary<string, EventHandler> _eventsDictionary
            = new Dictionary<string, EventHandler>();
        
        /// <summary>
        /// Executed from unity animator with given key!
        /// </summary>
        /// <param name="key"></param>
        public void RaiseEvent(string key)
        {
            if (_eventsDictionary.TryGetValue(key, out var handler))
            {
                handler?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Subscribe(string key, EventHandler handler)
        {
            if (!_eventsDictionary.ContainsKey(key))
            {
                _eventsDictionary.Add(key, null);
            }

            _eventsDictionary[key] += handler;
        }

        public void Unsubscribe(string key, EventHandler handler)
        {
            if (!_eventsDictionary.ContainsKey(key))
            {
                Debug.LogError($"Animation event handler of {gameObject.name} doesn't have {key} key");
                return;
            }
            
            _eventsDictionary[key] -= handler;
        }
    }
}