using UnityEngine;

namespace PlayerModules
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector2 MovementInput =>
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        public bool AttackPressed => Input.GetButtonDown("Fire1");
        public bool EnterPressed => Input.GetKeyDown(KeyCode.Return);
    }
}
