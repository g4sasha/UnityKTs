using System.Collections;
using TMPro;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private float _animationDuration;

        [SerializeField]
        private TMP_Text _healthTextField;

        [SerializeField]
        private SpriteRenderer _playerSpriteRenderer;

        private float _previousHealth;
        private Coroutine _damageAnimation;

        public void DisplayHealth(float health)
        {
            _healthTextField.text = $"Health: {health}";

            if (health < _previousHealth && _damageAnimation == null)
            {
                _damageAnimation = StartCoroutine(DamageAnimationRoutine());
            }

            _previousHealth = health;
        }

        public void Death()
        {
            _healthTextField.text = "YOU DIED";

            if (_damageAnimation != null)
            {
                StopCoroutine(_damageAnimation);
                _damageAnimation = null;
            }

            _playerSpriteRenderer.color = Color.black;
        }

        private IEnumerator DamageAnimationRoutine()
        {
            _playerSpriteRenderer.color = Color.red;
            yield return new WaitForSeconds(_animationDuration);
            _playerSpriteRenderer.color = Color.white;
            _damageAnimation = null;
        }
    }
}
