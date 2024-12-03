using PlayerModules;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput playerInput; // Ссылка на компонент ввода

        [SerializeField]
        private PlayerMovement playerMovement; // Ссылка на компонент движения

        [SerializeField]
        private PlayerCombat playerCombat; // Ссылка на компонент боя

        private StateMachine stateMachine;

        void Start()
        {
            // Инициализация StateMachine
            stateMachine = new StateMachine();

            // Создание состояний
            var shootingState = new ShootingState(playerInput, playerCombat);
            var highlightingState = new HighlightingState(playerInput, playerCombat);
            var transparencyState = new TransparencyState(playerInput, playerCombat);

            // Добавление состояний в StateMachine
            stateMachine.AddState(shootingState);
            stateMachine.AddState(highlightingState);
            stateMachine.AddState(transparencyState);

            // Установка начального состояния
            stateMachine.SetInitialState(shootingState);
        }

        void Update()
        {
            // Переключение состояний по Enter
            if (playerInput.EnterPressed)
            {
                stateMachine.TransitionToNextState();
            }

            // Передача ввода для движения
            playerMovement.Move(playerInput.MovementInput);

            // Обновление текущего состояния
            stateMachine.Update();
        }
    }
}
