using Source.Level;
using Source.Player;
using UnityEngine;

namespace Source.Core
{
    public class Game
    {
        private InputManager _inputManager;
        private PlayerMovement _playerMovement;
        private CameraController _cameraController;

        public Game(InputManager input, PlayerMovement playerMovement, CameraController cameraController)
        {
            _inputManager = input;
            _playerMovement = playerMovement;
            _cameraController = cameraController;
        }

        public void StartGame()
        {
            EnableInput();
            BindEvents();
            _cameraController.BindParameterCamera();
        }
        private void EnableInput()
        {
            _inputManager.Enable();
        }

        private void DisableInput()
        {
            _inputManager.Disable();
        }

        private void BindEvents()
        {
            _inputManager.Player.MoveUp.performed += _playerMovement.Input;
            _inputManager.Player.MoveLeft.performed += _playerMovement.Input;
            _inputManager.Player.MoveRight.performed += _playerMovement.Input;
        }

        private void UnSubscribeEvents()
        {
            _inputManager.Player.MoveUp.performed -= _playerMovement.Input;
            _inputManager.Player.MoveLeft.performed -= _playerMovement.Input;
            _inputManager.Player.MoveRight.performed -= _playerMovement.Input;
        }
    }
}
