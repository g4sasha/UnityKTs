using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private PlayerController _playerController;

        public void Construct(PlayerController playerController)
        {
            _playerController = playerController;
        }

        private void Update()
        {
            HandleClick();
            HandleMovement();
        }

        private void HandleClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerController.TakeDamage();
            }
        }

        private void HandleMovement()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            var direction = new Vector2(horizontal, vertical);

            _playerController.Move(direction);
        }
    }
}
