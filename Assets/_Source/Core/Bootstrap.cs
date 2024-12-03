using PlayerModules;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput _playerInput;

        [SerializeField]
        private PlayerMovement _playerMovement;

        [SerializeField]
        private PlayerCombat _playerCombat;

        [SerializeField]
        private TMPro.TextMeshProUGUI _hudText;

        private StateMachine _stateMachine;

        private void Start()
        {
            _stateMachine = new StateMachine();

            var shootingState = new ShootingState(_playerInput, _playerCombat, _hudText);
            var highlightingState = new HighlightingState(_playerInput, _playerCombat, _hudText);
            var transparencyState = new TransparencyState(_playerInput, _playerCombat, _hudText);

            _stateMachine.AddState(shootingState);
            _stateMachine.AddState(highlightingState);
            _stateMachine.AddState(transparencyState);

            _stateMachine.SetInitialState(shootingState);
        }

        private void Update()
        {
            if (_playerInput.EnterPressed)
            {
                _stateMachine.TransitionToNextState();
            }

            _playerMovement.Move(_playerInput.MovementInput);

            _stateMachine.Update();
        }
    }
}
