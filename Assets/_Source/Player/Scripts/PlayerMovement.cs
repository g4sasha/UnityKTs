using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private Rigidbody2D _rigidbody;
        private PlayerDataSO _data;

        public PlayerMovement(Rigidbody2D rigidbody, PlayerDataSO data)
        {
            _rigidbody = rigidbody;
            _data = data;
        }

        public void Move(float moveX, float speedModifier)
        {
            if (Mathf.Abs(_rigidbody.linearVelocityY) >= 1f)
            {
                _rigidbody.linearVelocityX = moveX * _data.Speed * speedModifier;
            }
        }

        public void Up()
        {
            _rigidbody.linearVelocityY = 0f;
            _rigidbody.AddForce(Vector2.up * _data.UpForce, ForceMode2D.Impulse);
        }
    }
}
