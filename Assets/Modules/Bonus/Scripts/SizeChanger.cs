using Extention;
using Player;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    [SerializeField]
    private float _sizeModifier;

    [SerializeField]
    private LayerMask _playerLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.IsInLayer(_playerLayer))
        {
            var pl = other.GetComponent<PlayerSetup>();
            pl.Scale *= _sizeModifier;
            Destroy(gameObject);
        }
    }
}
