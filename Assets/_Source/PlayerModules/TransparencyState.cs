using Core;
using UnityEngine;

namespace PlayerModules
{
    public class TransparencyState : IState
    {
        private PlayerInput input;
        private PlayerCombat combat;
        private bool isTransparent;

        public TransparencyState(PlayerInput input, PlayerCombat combat)
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
                ToggleTransparency();
            }
        }

        private void ToggleTransparency()
        {
            isTransparent = !isTransparent;
            combat.spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, isTransparent ? 0.5f : 1.0f);
        }
    }
}
