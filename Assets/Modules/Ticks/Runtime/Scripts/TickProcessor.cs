using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Modules.Ticks.Runtime
{
    internal class TickProcessor : MonoBehaviour
    {
        public GameObject Processor => gameObject;

        public readonly VirtualTickController<ITickUpdate> TickUpdates 
            = new VirtualTickController<ITickUpdate>();
        public readonly VirtualTickController<ITickFixedUpdate> TickFixedUpdates 
            = new VirtualTickController<ITickFixedUpdate>();
        public readonly VirtualTickController<ITickLateUpdate> TickLateUpdates
            = new VirtualTickController<ITickLateUpdate>();

        private void Update()
        {
            TickUpdates.Tick();
        }
        
        private void FixedUpdate()
        {
            TickFixedUpdates.Tick();
        }

        private void LateUpdate()
        {
            TickLateUpdates.Tick();
        }

        private void OnDestroy()
        {
            TickUpdates.Clear();
            TickFixedUpdates.Clear();
            TickLateUpdates.Clear();
        }
    }
}