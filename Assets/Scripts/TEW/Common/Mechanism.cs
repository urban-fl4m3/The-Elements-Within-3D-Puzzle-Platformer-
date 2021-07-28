using System.Collections.Generic;
using Modules.Common.Runtime;
using TEW.Common.Components;
using UnityEngine;

namespace TEW.Common
{
    public abstract class Mechanism : MonoBehaviour
    {
        public abstract IReadonlyDynamicProperty<bool> IsEnabled { get; }
        
        protected abstract IEnumerable<IMechanismComponent> MechanismComponents { get; }

        protected abstract void CreateCallback();
        protected abstract void DestroyCallback();
        protected abstract void ActivateCallback();
        protected abstract void DeactivateCallback();

        private void Awake()
        {
            CreateCallback();
        }

        private void OnDestroy()
        {
            DestroyCallback();
        }

        private void OnEnable()
        {
            foreach (var component in MechanismComponents)
            {
                component.Activate();
            }    
            
            ActivateCallback();
        }

        private void OnDisable()
        {
            foreach (var component in MechanismComponents)
            {
                component.Deactivate();
            }
            
            DeactivateCallback();
        }
    }
}