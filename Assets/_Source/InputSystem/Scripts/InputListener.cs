using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        public bool IsUp { get; private set; }

        public float Horizontal { get; private set; }

        private void Update()
        {
            HandleMovement();
            HandleJump();
            HandleRestart();
        }

        private void HandleMovement()
        {
            Horizontal = Input.GetAxis("Horizontal");
        }

        private void HandleJump()
        {
            if (Input.GetButton("Jump"))
            {
                IsUp = true;
            }
            else
            {
                IsUp = false;
            }
        }

        private void HandleRestart()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
