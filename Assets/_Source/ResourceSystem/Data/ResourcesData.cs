using UnityEngine;

namespace ResourceSystem.Data
{
    [System.Serializable]
    public class ResourcesData
    {
        [field: SerializeField]
        public ResourceType ResourceType { get; private set; }

        [field: SerializeField]
        public float EnableTime { get; private set; }

        [field: SerializeField]
        public float DisableTime { get; private set; }
    }
}
