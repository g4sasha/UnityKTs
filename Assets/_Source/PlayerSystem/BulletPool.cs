using System;
using System.Collections.Generic;
using PoolSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class BulletPool : IPool<Bullet>, IDisposable
    {
        public int Count => _pool.Count;

        private readonly Queue<Bullet> _pool = new();

        private Bullet _bulletPrefab;

        public BulletPool(Bullet bulletPrefab, int initSize)
        {
            InitPool(bulletPrefab, initSize);
        }

        public BulletPool(Bullet[] bullets)
        {
            InitPool(bullets);
        }

        public void InitPool(Bullet bulletPrefab, int initSize)
        {
            _bulletPrefab = bulletPrefab;

            for (int i = 0; i < initSize; i++)
            {
                _ = InstantiatePoolObject(bulletPrefab);
            }
        }

        public void InitPool(Bullet[] bullets)
        {
            foreach (var bullet in bullets)
            {
                ReturnToPool(bullet);
            }
        }

        public Bullet GetFromPool()
        {
            Bullet bullet;

            if (_pool.TryDequeue(out bullet))
            {
                return bullet;
            }

            bullet = InstantiatePoolObject(_bulletPrefab);

            return bullet;
        }

        public void ReturnToPool(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            _pool.Enqueue(bullet);
        }

        public void Dispose()
        {
            foreach (var bullet in _pool)
            {
                bullet.OnBulletDisable -= ReturnToPool;
            }
        }

        public Bullet InstantiatePoolObject(Bullet bulletPrefab)
        {
            var bulletInstance = GameObject.Instantiate(bulletPrefab);
            ReturnToPool(bulletInstance);
            bulletInstance.OnBulletDisable += ReturnToPool;
            return bulletInstance;
        }
    }
}
