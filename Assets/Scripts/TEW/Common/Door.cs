using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TEW.Common
{
    public class Door: MonoBehaviour
    {
        public List<Mechanism> mechanismContainers;
        public Animator animator;
        private void Start()
        {
            foreach (var mechanism in mechanismContainers)
            {
                    mechanism.DynamicProperty.Changed += OnChange;
            }
        }

        private void OnChange(object sender, bool e)
        {
            var a = mechanismContainers.Aggregate(true, (current, mechanism) => current && mechanism.DynamicProperty.Value);
            animator.Play(a ? "Open" : "Close");
        }
    }
}