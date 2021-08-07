using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TEW.Common
{
    public class DoorComponent: MonoBehaviour
    {
        [SerializeField] private List<Mechanism> mechanisms;
        [SerializeField] private Animator animator;
        
        private static readonly int IsOpened = Animator.StringToHash("IsOpened");

        private void OnEnable()
        {
            foreach (var mechanism in mechanisms)
            {
                mechanism.IsEnabled.Changed += HandleMechanismStateChanged;
            }
        }
        
        private void OnDisable()
        {
            foreach (var mechanism in mechanisms)
            {
                mechanism.IsEnabled.Changed -= HandleMechanismStateChanged;
            }
        }
        
        private void HandleMechanismStateChanged(object sender, bool e)
        {
            Debug.Log("A");
            var readyToOpen = mechanisms
                .Aggregate(true, (current, container) => current && container.IsEnabled.Value);

            animator.SetBool(IsOpened, readyToOpen);
        }
    }
}