using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Initial Values")]
        [SerializeField]
        private float _initialPlayerHealth;

        [SerializeField]
        private float _initialPlayerSpeed;

        [Header("Modules")]
        [SerializeField]
        private PlayerView _playerView;

        [SerializeField]
        private Transform _playerTransform;

        [SerializeField]
        private InputListener _inputListener;

        private PlayerController _playerController;
        private PlayerModel _playerModel;

        private void Awake()
        {
            _playerModel = new(_initialPlayerHealth, _playerTransform, _initialPlayerSpeed);
            _playerController = new(_playerModel, _playerView);
            _inputListener.Construct(_playerController);

            _playerController.Subscribe();
        }

        private void OnDestroy()
        {
            _playerController.Unsubscribe();
        }
    }
}
