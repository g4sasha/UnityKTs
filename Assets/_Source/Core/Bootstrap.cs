using System;
using System.Collections.Generic;
using InputSystem;
using PlayerSystem;
using PoolSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        [SerializeField]
        private PlayerShooter _playerShooter;

        [SerializeField]
        private InputListener _inputListener;

        private IPool<Bullet> _bulletPool;

        private List<IDisposable> _disposables = new List<IDisposable>();

        private void Start()
        {
            _bulletPool = new BulletPool(bulletPrefab, 3);
            _disposables.Add(_bulletPool as IDisposable);
            _playerShooter.Construct(_bulletPool);
            _inputListener.Construct(_playerShooter);
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
