using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "NewResourcesData", menuName = "ResourceSystem/ResourcesData")]
    public class ResourcesDataSO : ScriptableObject
    {
        [field: SerializeField]
        public List<ResourcesData> ResourcesData { get; private set; }

        public bool TryGetDecayTime(ResourceType type, out float decayTime)
        {
            decayTime = 0f;

            foreach (var data in ResourcesData)
            {
                if (data.ResourceType == type)
                {
                    decayTime = data.DecayTime;
                    return true;
                }
            }

            return false;
        }

        public bool TryGetEnrichmentTime(ResourceType type, out float enrichmentTime)
        {
            enrichmentTime = 0f;

            foreach (var data in ResourcesData)
            {
                if (data.ResourceType == type)
                {
                    enrichmentTime = data.EnrichmentTime;
                    return true;
                }
            }

            return false;
        }
    }
}
