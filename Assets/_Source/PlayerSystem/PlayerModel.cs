using System;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerModel
    {
        public event Action<float> OnHealthChanged;
        public event Action OnDeath;

        public float MaxHealth { get; }

        public float Health
        {
            get => _health;
            private set
            {
                _health = value;
                OnHealthChanged?.Invoke(Health);

                if (Health == 0f)
                {
                    OnDeath?.Invoke();
                }
            }
        }

        private float _health;

        private float _movementSpeed;
        private Transform _transform;

        public PlayerModel(float maxHealth, Transform transform, float movementSpeed)
        {
            if (maxHealth <= 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(maxHealth));
            }

            MaxHealth = maxHealth;
            Health = MaxHealth;

            _transform = transform;
            _movementSpeed = movementSpeed;
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(damage));
            }

            Health = Mathf.Max(0f, Health - damage);
        }

        public void Move(Vector2 direction)
        {
            _transform.Translate(direction.normalized * _movementSpeed * Time.deltaTime);
        }
    }
}
