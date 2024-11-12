using Extention;
using UnityEngine;

namespace DynamicObects
{
    public class SpikeTrigger : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _parentRb;

        [SerializeField]
        private LayerMask _playerLayer;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.IsInLayer(_playerLayer))
            {
                _parentRb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
