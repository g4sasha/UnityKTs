using Core;
using UnityEngine;

namespace PlayerModules
{
    public class ShootingState : IState
    {
        private PlayerInput input;
        private PlayerCombat combat;

        public ShootingState(PlayerInput input, PlayerCombat combat)
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
                Shoot();
            }
        }

        private void Shoot()
        {
            GameObject bullet = Object.Instantiate(
                combat.bulletPrefab,
                combat.firePoint.position,
                Quaternion.identity
            );
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f;
        }
    }
}
