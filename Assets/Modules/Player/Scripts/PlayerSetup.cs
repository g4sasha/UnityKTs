using InputSystem;
using UnityEngine;

namespace Player
{
    public class PlayerSetup : MonoBehaviour
    {
        public float Scale = 1f;

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
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                _rigidbody.angularVelocity = 0f;
            }
        }

        private void Flip()
        {
            if (_rigidbody.linearVelocityX >= _playerData.Speed / 2f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f) * Scale;
                IsFacingRight = true;
            }

            if (_rigidbody.linearVelocityX <= -_playerData.Speed / 2f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f) * Scale;
                IsFacingRight = false;
            }
        }
    }
}
