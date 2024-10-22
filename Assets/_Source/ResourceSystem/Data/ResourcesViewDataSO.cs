using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(
        fileName = "NewResourcesViewData",
        menuName = "ResourceSystem/ResourcesViewData"
    )]
    public class ResourcesViewDataSO : ScriptableObject
    {
        [field: SerializeField]
        public List<ResourcesViewData> ResourcesViewData { get; private set; }

        public bool TryGetEnabledIcon(ResourceType type, out Sprite icon)
        {
            icon = null;

            foreach (var data in ResourcesViewData)
            {
                if (data.ResourceType == type)
                {
                    icon = data.EnabledIcon;
                    return true;
                }
            }

            return false;
        }

        public bool TryGetDisabledIcon(ResourceType type, out Sprite icon)
        {
            icon = null;

            foreach (var data in ResourcesViewData)
            {
                if (data.ResourceType == type)
                {
                    icon = data.DisabledIcon;
                    return true;
                }
            }

            return false;
        }
    }
}
