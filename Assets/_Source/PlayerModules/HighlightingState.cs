using Core;

namespace PlayerModules
{
    public class HighlightingState : IState
    {
        private PlayerInput _input;
        private PlayerCombat _combat;
        private TMPro.TextMeshProUGUI _hudText;
        private bool _isHighlighting;

        public HighlightingState(
            PlayerInput input,
            PlayerCombat combat,
            TMPro.TextMeshProUGUI hudText
        )
        {
            _input = input;
            _combat = combat;
            _hudText = hudText;
            _isHighlighting = false;
        }

        public void Enter()
        {
            _hudText.text = "Current State: Highlighting";
            _combat.RedZone.SetActive(false);
        }

        public void Exit()
        {
            _combat.RedZone.SetActive(false);
        }

        public void Update()
        {
            if (_input.AttackPressed)
            {
                _isHighlighting = !_isHighlighting;
                _combat.RedZone.SetActive(_isHighlighting);
            }
        }
    }
}
