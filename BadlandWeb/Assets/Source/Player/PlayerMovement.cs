using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Player
{
    public class PlayerMovement
    {

        private PlayerMovementComponent _player;

        public PlayerMovement(PlayerMovementComponent playerMovementComponent)
        {
            _player = playerMovementComponent;
        }
        public void Input(InputAction.CallbackContext button)
        {
            switch (button.control.name)
            {
                case"space":
                    _player.WakeUp(button.ReadValue<float>());
                    break;
                case "a":
                    _player.WakeLeft(button.ReadValue<float>());
                    break;
                case "d":
                    _player.WakeRight(button.ReadValue<float>());
                    break;
            }
        }
    }
}
