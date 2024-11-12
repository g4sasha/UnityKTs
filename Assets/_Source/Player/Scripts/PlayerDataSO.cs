using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData")]
    public class PlayerDataSO : ScriptableObject
    {
        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public float UpForce { get; private set; }
    }
}
