using UnityEngine;

namespace ResourceSystem.Data
{
    [System.Serializable]
    public class ResourcesViewData
    {
        [field: SerializeField]
        public ResourceType ResourceType { get; private set; }

        [field: SerializeField]
        public Sprite EnabledIcon { get; private set; }

        [field: SerializeField]
        public Sprite DisabledIcon { get; private set; }
    }
}
