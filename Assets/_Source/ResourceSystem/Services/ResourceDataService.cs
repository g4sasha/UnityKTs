using Core;
using ResourceSystem.Data;
using UnityEngine;

namespace ResourceSystem.Services
{
    public class ResourceDataService
    {
        public static ResourceDataService Instance
        {
            get
            {
                _instance ??= new ResourceDataService();
                return _instance;
            }
        }

        private static ResourceDataService _instance;

        private ResourcesDataSO Data
        {
            get
            {
                if (_data == null)
                {
                    _data = Resources.Load(PathData.RESOURCE_VIEW_DATA_PATH) as ResourcesDataSO;
                }

                return _data;
            }
        }

        private ResourcesDataSO _data;

        public bool TryGetDecayTime(ResourceType type, out float decayTime)
        {
            decayTime = 0f;

            if (Data.TryGetDecayTime(type, out var newDecayTime))
            {
                decayTime = newDecayTime;
                return true;
            }

            return false;
        }

        public bool TryGetEnrichmentTime(ResourceType type, out float enrichmentTime)
        {
            enrichmentTime = 0f;

            if (Data.TryGetEnrichmentTime(type, out var newEnrichmentTime))
            {
                enrichmentTime = newEnrichmentTime;
                return true;
            }

            return false;
        }
    }
}
