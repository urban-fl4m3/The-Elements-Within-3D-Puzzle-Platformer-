using System;
using UnityEngine;
using UnityEngine.UI;

namespace TEW.Common.Game
{
    public class LoadingScene: MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Animator _animator;

        public bool CheckIsAnimationEnd()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Shading");
        }
        
        public void SetSliderValue(float progress)
        {
            _slider.value = progress;
        }
    }
}