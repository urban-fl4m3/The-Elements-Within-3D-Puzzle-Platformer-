using System;
using UnityEngine;

namespace TEW.Common.Components
{
    [RequireComponent(typeof(Animator))]
    public class IkAnimationComponent : MonoBehaviour
    {
        public event EventHandler<int> AnimatorIkTick;
        
        private void OnAnimatorIK(int layerIndex)
        {
            AnimatorIkTick?.Invoke(this, layerIndex);    
        }
    }
}