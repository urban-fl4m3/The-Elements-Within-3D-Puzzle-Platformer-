using System;
using TEW.Common.Rendering.Helpers;
using UnityEngine;

namespace TEW.Common.Rendering.Models
{
    [Serializable]
    public class CameraBehaviourModel
    {
        [SerializeField] private CameraActor _camera;
        [SerializeField] private CameraBehaviour _cameraBehaviour;

        public IActiveCamera Camera => _camera;
        public CameraBehaviour Behaviour => _cameraBehaviour;
    }
}