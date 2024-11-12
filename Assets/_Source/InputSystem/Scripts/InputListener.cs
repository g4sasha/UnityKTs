using System;
using UnityEngine;

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
    }
}
