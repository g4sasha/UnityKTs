using UnityEngine;

namespace PlayerSystem
{
    public class PlayerController
    {
        private const float CLICK_DAMAGE = 12f;

        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        private bool _alive = true;

        public PlayerController(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;

            _view.DisplayHealth(_model.Health);
        }

        public void Subscribe()
        {
            _model.OnHealthChanged += _view.DisplayHealth;
            _model.OnDeath += _view.Death;
            _model.OnDeath += () => _alive = false;
        }

        public void Unsubscribe()
        {
            _model.OnHealthChanged -= _view.DisplayHealth;
            _model.OnDeath -= _view.Death;
            _model.OnDeath -= () => _alive = false;
        }

        public void TakeDamage() => _model.TakeDamage(CLICK_DAMAGE);

        public void Move(Vector2 direction)
        {
            if (!_alive)
            {
                return;
            }

            _model.Move(direction);
        }
    }
}
