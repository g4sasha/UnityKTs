using System;
using System.Collections;
using PoolSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class Bullet : MonoBehaviour, IPoolableObject
    {
        public event Action<Bullet> OnBulletDisable;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _lifeTime;

        private void OnEnable()
        {
            StartCoroutine(LifeTime(_lifeTime));
        }

        private void OnDisable()
        {
            OnBulletDisable?.Invoke(this);
        }

        private void Update()
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }

        private IEnumerator LifeTime(float lifeTime)
        {
            yield return new WaitForSeconds(lifeTime);
            gameObject.SetActive(false);
        }
    }
}
