using InputSystem;
using PoolSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField]
        private Transform _firePoint;

        [SerializeField]
        private InputListener _inputListener;

        private IPool<Bullet> _bulletPool;

        private float _lookDirection;

        public void Construct(IPool<Bullet> bulletPool)
        {
            _bulletPool = bulletPool;
        }

        private void Update()
        {
            var direction = _inputListener.WorldMousePosition - _firePoint.position;
            _lookDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, _lookDirection - 90f);
        }

        public void Shoot()
        {
            var bullet = _bulletPool.GetFromPool();

            bullet.transform.position = _firePoint.position;

            bullet.transform.rotation = Quaternion.Euler(0f, 0f, _lookDirection - 90f);
            bullet.gameObject.SetActive(true);
        }
    }
}
