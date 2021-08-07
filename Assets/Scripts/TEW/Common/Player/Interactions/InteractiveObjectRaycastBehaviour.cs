using System;
using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using TEW.Common.World.Interactive;
using UnityEngine;

namespace TEW.Common.Player.Interactions
{
    public class InteractiveObjectRaycastBehaviour : ITickFixedUpdate, IDisposable
    {
        public bool Enabled { get; set; }

        private readonly float _radius;
        private readonly Transform _origin;
        private readonly LayerMask _interactiveLayer;
        private readonly IProperty<IInteractable> _interactiveObject;

        private RaycastHit _interactiveHit;
        
        public InteractiveObjectRaycastBehaviour(Transform origin, LayerMask interactiveLayer, float radius,
            IProperty<IInteractable> interactiveObject)
        {
            _origin = origin;
            _radius = radius;
            _interactiveLayer = interactiveLayer;
            _interactiveObject = interactiveObject;
        }
        
        public void Tick()
        {
            var interactiveObjectFound = Physics.Raycast(_origin.position, _origin.forward, out _interactiveHit,
                _radius, _interactiveLayer);

            if (interactiveObjectFound)
            {
                var interactable = _interactiveHit.collider.gameObject.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    _interactiveObject.Value = interactable;
                }
            }
        }

        public void Dispose()
        {
            
        }
    }
}