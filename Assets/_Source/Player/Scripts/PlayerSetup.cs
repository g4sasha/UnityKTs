using Extention;
using InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerSetup : MonoBehaviour
    {
        [SerializeField]
        private float _scale = 1f;
        public bool IsFacingRight { get; private set; } = true;

        [SerializeField]
        private PlayerDataSO _playerData;

        [SerializeField]
        private InputListener _inputListener;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private LayerMask _respawnLayer;

        private PlayerMovement _movement;
        private float _speedModifier = 1f;

        private void Awake()
        {
            _movement = new PlayerMovement(_rigidbody, _playerData);
            ApplyScale();
        }

        private void Update()
        {
            Move();
            Jump();
            Flip();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.IsInLayer(_respawnLayer))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public void ChangeScale(float sizeModifier)
        {
            _scale *= sizeModifier;
            ApplyScale(IsFacingRight ? 1 : -1);
        }

        public void ChangeSpeed(float speedModifier)
        {
            _speedModifier *= speedModifier;
        }

        private void Move()
        {
            _movement.Move(_inputListener.Horizontal, _speedModifier);
        }

        private void Jump()
        {
            if (_inputListener.IsUp)
            {
                _movement.Up();
                ResetRotation();
            }
        }

        private void Flip()
        {
            float velocityX = _rigidbody.linearVelocityX;
            if (velocityX >= _playerData.Speed / 2f && !IsFacingRight)
            {
                IsFacingRight = true;
                ApplyScale(1);
            }
            else if (velocityX <= -_playerData.Speed / 2f && IsFacingRight)
            {
                IsFacingRight = false;
                ApplyScale(-1);
            }
        }

        private void ApplyScale(float direction = 1)
        {
            transform.localScale = new Vector3(direction, 1f, 1f) * _scale;
        }

        private void ResetRotation()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            _rigidbody.angularVelocity = 0f;
        }
    }
}
