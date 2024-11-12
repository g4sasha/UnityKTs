using Extention;
using Player;
using UnityEngine;

// TODO: пофиксить дубляж кода generic'ами
public class SpeedChanger : MonoBehaviour
{
    [SerializeField]
    private float _speedModifier;

    [SerializeField]
    private LayerMask _playerLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.IsInLayer(_playerLayer))
        {
            var player = other.GetComponent<PlayerSetup>();
            player.ChangeSpeed(_speedModifier);
            Destroy(gameObject);
        }
    }
}
