using UnityEngine;

namespace ResourceSystem.Data
{
    [System.Serializable]
    public class ResourcesData
    {
        [field: SerializeField]
        public ResourceType ResourceType { get; private set; }

        [field: SerializeField]
        public float DecayTime { get; private set; }

        [field: SerializeField]
        public float EnrichmentTime { get; private set; }
    }
}
