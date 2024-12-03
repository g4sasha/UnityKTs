using Core;
using UnityEngine;

namespace PlayerModules
{
    public class ShootingState : IState
    {
        private PlayerInput _input;
        private PlayerCombat _combat;
        private TMPro.TextMeshProUGUI _hudText;

        public ShootingState(PlayerInput input, PlayerCombat combat, TMPro.TextMeshProUGUI hudText)
        {
            _input = input;
            _combat = combat;
            _hudText = hudText;
        }

        public void Enter()
        {
            _hudText.text = "Current State: Shooting";
        }

        public void Exit() { }

        public void Update()
        {
            if (_input.AttackPressed)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Object.Instantiate(
                _combat.BulletPrefab,
                _combat.FirePoint.position,
                Quaternion.identity
            );
        }
    }
}
