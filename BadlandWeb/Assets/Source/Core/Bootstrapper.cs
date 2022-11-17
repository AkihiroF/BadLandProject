using System;
using System.Collections.Generic;
using Cinemachine;
using Source.Level;
using Source.Player;
using UnityEngine;

namespace Source.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private List<PartLocation> partsLocation;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        private PlayerMovementComponent _playerMovementComponent;
        private PlayerMovement _playerMovement;
        private InputManager _inputManager;
        private Game _game;
        private LocationCreator _locationCreator;
        private CameraController _cameraController;
        private void Awake()
        {
            _locationCreator = new LocationCreator(partsLocation);
            _playerMovementComponent = Instantiate(playerPrefab, _locationCreator.PointSpawnPlayer().position, Quaternion.identity).
                GetComponent<PlayerMovementComponent>();
            
            _playerMovement = new PlayerMovement(_playerMovementComponent);
            _inputManager = new InputManager();
            _cameraController = new CameraController(virtualCamera, _playerMovementComponent.transform);
            _game = new Game(_inputManager, _playerMovement, _cameraController);
            CreateMap(_locationCreator.GetLocation());
        }

        private void CreateMap(Dictionary<GameObject, Vector2> loc)
        {
            var keys = loc.Keys;
            foreach (var part in keys)
            {
                Instantiate(part, loc[part], Quaternion.identity);
            }
            _game.StartGame();
        }
    }
}
