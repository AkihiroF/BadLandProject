using Cinemachine;
using UnityEngine;

namespace Source.Level
{
    public class CameraController
    {
        private CinemachineVirtualCamera _virtualCamera;
        private Transform _player;
        public CameraController(CinemachineVirtualCamera virtualCamera, Transform player)
        {
            _player = player;
            _virtualCamera = virtualCamera;
        }

        public void BindParameterCamera()
        {
            _virtualCamera.Follow = _player;
        }
    }
}
