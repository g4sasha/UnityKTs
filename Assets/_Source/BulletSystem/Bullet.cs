using UnityEngine;

namespace BulletSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float _bulletSpeed = 10f;

        [SerializeField]
        float _bulletLifetime = 5f;

        private void OnEnable()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * _bulletSpeed;
            Destroy(gameObject, _bulletLifetime);
        }
    }
}
