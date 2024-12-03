using System.Collections.Generic;

namespace Core
{
    public class StateMachine
    {
        private List<IState> _states = new List<IState>();
        private IState _currentState;
        private int _currentStateIndex = 0;

        public void AddState(IState state)
        {
            _states.Add(state);
        }

        public void SetInitialState(IState state)
        {
            _currentState = state;
            _currentStateIndex = _states.IndexOf(state);
            _currentState.Enter();
        }

        public void TransitionToNextState()
        {
            _currentState.Exit();

            _currentStateIndex = (_currentStateIndex + 1) % _states.Count;
            _currentState = _states[_currentStateIndex];

            _currentState.Enter();
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}
