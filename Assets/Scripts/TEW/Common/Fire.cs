using System;
using UnityEngine;

namespace TEW.Common
{
    public class Fire: MonoBehaviour
    {
        public Mechanism Mechanism;
        public ParticleSystem ParticleSystem;
        private void Start()
        {
            Mechanism.DynamicProperty.Changed += OnChange;
            TurnOn(Mechanism.DynamicProperty.Value);
        }

        private void OnChange(object sender, bool e)
        {
            TurnOn(e);
        }

        private void TurnOn(bool enableParticle)
        {
            if (enableParticle)
            {
                ParticleSystem.Play();
            }
            else
            {
                ParticleSystem.Stop();
            }
        }
    }
}