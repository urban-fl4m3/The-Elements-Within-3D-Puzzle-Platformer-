using System.Collections.Generic;
using System.Linq;
using TEW.Common.Rendering.Helpers;
using TEW.Common.Rendering.Models;

namespace TEW.Common.Rendering
{
    public class CameraController
    {
        public IActiveCamera CurrentGameCamera { get; private set; }
        
        private readonly Dictionary<CameraBehaviour, IActiveCamera> _cameras;

        private CameraBehaviour _currentBehaviour;
        
        public CameraController(params CameraBehaviourModel[] cameraModels)
        {
            _cameras = cameraModels.ToDictionary(x => x.Behaviour, x => x.Camera);
        }

        public void ChangeActiveCamera(CameraBehaviour behaviour)
        {
            if (_currentBehaviour == behaviour)
            {
                return;
            }
            
            CurrentGameCamera?.Deactivate();

            if (_cameras.TryGetValue(behaviour, out var camera))
            {
                camera.Activate();
                _currentBehaviour = behaviour;
                CurrentGameCamera = camera;
            }
        }
    }
}