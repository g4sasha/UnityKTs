using System.Collections.Generic;

namespace Core
{
    public class StateMachine
    {
        private List<IState> states = new List<IState>();
        private IState currentState;
        private int currentStateIndex = 0;

        public void AddState(IState state)
        {
            states.Add(state);
        }

        public void SetInitialState(IState state)
        {
            currentState = state;
            currentStateIndex = states.IndexOf(state);
            currentState.Enter();
        }

        public void TransitionToNextState()
        {
            currentState.Exit();

            // Переход к следующему состоянию
            currentStateIndex = (currentStateIndex + 1) % states.Count;
            currentState = states[currentStateIndex];

            currentState.Enter();
        }

        public void Update()
        {
            currentState?.Update();
        }
    }
}
