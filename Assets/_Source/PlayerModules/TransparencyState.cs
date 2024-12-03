using Core;

namespace PlayerModules
{
    public class TransparencyState : IState
    {
        private PlayerInput _input;
        private PlayerCombat _combat;
        private TMPro.TextMeshProUGUI _hudText;
        private bool _isTransparent;

        public TransparencyState(
            PlayerInput input,
            PlayerCombat combat,
            TMPro.TextMeshProUGUI hudText
        )
        {
            _input = input;
            _combat = combat;
            _hudText = hudText;
            _isTransparent = false;
        }

        public void Enter()
        {
            _hudText.text = "Current State: Transparency";
            SetTransparency(false);
        }

        public void Exit()
        {
            SetTransparency(false);
        }

        public void Update()
        {
            if (_input.AttackPressed)
            {
                _isTransparent = !_isTransparent;
                SetTransparency(_isTransparent);
            }
        }

        private void SetTransparency(bool transparent)
        {
            var color = _combat.SpriteRenderer.color;
            color.a = transparent ? 0.5f : 1f;
            _combat.SpriteRenderer.color = color;
        }
    }
}
