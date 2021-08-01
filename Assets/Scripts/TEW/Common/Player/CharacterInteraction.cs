using System.Collections.Generic;
using Modules.Ticks.Runtime;
using UnityEngine;

namespace TEW.Common.Player
{
    public class CharacterInteraction: MonoBehaviour, ITickUpdate
    {
        public bool Enabled { get; set; }
        
        public Transform player;
        public Vector2 angleLimit;
        private readonly List<Mechanism> _mechanisms = new List<Mechanism>();
        private Mechanism _mechanismToActivate;
        
        private void Start()
        {
            TickManager.AddTick(this,this);
        }
        
        public void Tick()
        {
            if(_mechanisms.Count == 0)
                return;

            _mechanismToActivate = null;
            
            foreach (var mechanism in _mechanisms)
            {
                var targetDirection = mechanism.transform.position - player.position;
                var angle = Vector3.SignedAngle(targetDirection, player.forward, Vector3.up);
                if (IsInLimit(angle, angleLimit.x, angleLimit.y))
                {
                    _mechanismToActivate = mechanism;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _mechanismToActivate.IsEnabled.Value =  !_mechanismToActivate.IsEnabled.Value;
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer($"Mechanism"))
            {
                _mechanisms.Add(other.GetComponent<Mechanism>());
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer($"Mechanism"))
            {
                _mechanisms?.Remove(other.GetComponent<Mechanism>());
            }
        }

        private static bool IsInLimit(float angle, float min, float max)
        {
            var a = angle > min;
            var b = angle < max;
            return a && b;
        }
    }
}