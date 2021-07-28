using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TEW.Common
{
    public class DoorComponent: MonoBehaviour
    {
        [SerializeField] private List<Mechanism> _mechanisms;
        [SerializeField] private Animator _animator;
        
        private static readonly int IsOpened = Animator.StringToHash("IsOpened");

        private void OnEnable()
        {
            foreach (var mechanism in _mechanisms)
            {
                mechanism.IsEnabled.Changed += HandleMechanismStateChanged;
            }
        }

        private void OnDisable()
        {
            foreach (var mechanism in _mechanisms)
            {
                mechanism.IsEnabled.Changed -= HandleMechanismStateChanged;
            }
        }

        private void HandleMechanismStateChanged(object sender, bool e)
        {
            var readyToOpen = _mechanisms
                .Aggregate(true, (current, container) => current && container.IsEnabled.Value);

            _animator.SetBool(IsOpened, readyToOpen);
        }
    }
}