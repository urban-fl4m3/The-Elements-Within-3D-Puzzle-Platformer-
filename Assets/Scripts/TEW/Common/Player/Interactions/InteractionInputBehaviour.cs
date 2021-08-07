using System;
using Modules.Common.Runtime;
using Modules.Ticks.Runtime;
using TEW.Common.World.Interactive;
using UnityEngine;

namespace TEW.Common.Player.Interactions
{
    public class InteractionInputBehaviour : ITickUpdate, IDisposable
    {
        public bool Enabled { get; set; }

        private readonly IDynamicProperty<IInteractable> _interactiveObject;
            
        public InteractionInputBehaviour(IDynamicProperty<IInteractable> interactiveObject)
        {
            _interactiveObject = interactiveObject;
            _interactiveObject.Changed += InteractiveObjectOnChanged;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactiveObject.Value?.Interact();
            }
        }

        public void Dispose()
        {
            _interactiveObject.Changed -= InteractiveObjectOnChanged;
        }

        private void InteractiveObjectOnChanged(object sender, IInteractable e)
        {
            Enabled = _interactiveObject.Value != null;
        }
    }
}