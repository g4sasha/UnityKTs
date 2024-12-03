using Core;

namespace PlayerModules
{
    public class HighlightingState : IState
    {
        private PlayerInput input;
        private PlayerCombat combat;
        private bool isHighlighted;

        public HighlightingState(PlayerInput input, PlayerCombat combat)
        {
            this.input = input;
            this.combat = combat;
        }

        public void Enter() { }

        public void Exit() { }

        public void Update()
        {
            if (input.AttackPressed)
            {
                ToggleHighlight();
            }
        }

        private void ToggleHighlight()
        {
            isHighlighted = !isHighlighted;
            combat.redZone.SetActive(isHighlighted);
        }
    }
}
