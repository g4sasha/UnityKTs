using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        public Vector3 WorldMousePosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);

        private PlayerShooter _playerShooter;

        public void Construct(PlayerShooter playerShooter)
        {
            _playerShooter = playerShooter;
        }

        private void Update()
        {
            HandleShoot();
        }

        private void HandleShoot()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _playerShooter.Shoot();
            }
        }
    }
}
