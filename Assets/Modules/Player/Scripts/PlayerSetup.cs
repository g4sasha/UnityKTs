using InputSystem;
using UnityEngine;

namespace Player
{
    public class PlayerSetup : MonoBehaviour
    {
        public bool IsFacingRight { get; private set; } = true;

        [SerializeField]
        private PlayerDataSO _playerData;

        [SerializeField]
        private InputListener _inputListener;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        private PlayerMovement _movement;

        private void Awake()
        {
            _movement = new PlayerMovement(_rigidbody, _playerData);
        }

        private void Update()
        {
            Move();
            Up();
            Flip();
        }

        private void Move()
        {
            _movement.Move(_inputListener.Horizontal);
        }

        private void Up()
        {
            if (_inputListener.IsUp)
            {
                _movement.Up();
            }
        }

        private void Flip()
        {
            if (_rigidbody.linearVelocityX >= _playerData.Speed / 2f)
            {
                transform.localScale = Vector2.right;
                IsFacingRight = true;
            }

            if (_rigidbody.linearVelocityX <= -_playerData.Speed / 2f)
            {
                transform.localScale = Vector2.left;
                IsFacingRight = false;
            }
        }
    }
}
