using TEW.Common.Player;
using TEW.Common.Rendering;
using TEW.Common.Rendering.Helpers;
using TEW.Common.Rendering.Models;
using UnityEngine;

namespace TEW.Common.Game
{
    public class World : MonoBehaviour
    {
        [SerializeField] private PlayerActor _playerActor;
        [SerializeField] private CameraBehaviourModel[] _cameraModels;

        private CameraController _cameraController;
        
        private void Start()
        {
            _cameraController = new CameraController(_cameraModels);
            ChangeActiveCamera(CameraBehaviour.ThirdPerson);
        }

        private void ChangeActiveCamera(CameraBehaviour behaviour)
        {
            _cameraController.ChangeActiveCamera(behaviour);
            _playerActor.MovementBehaviour = _cameraController.CurrentGameCamera.GetMovementBehaviour();
        }
    }
}