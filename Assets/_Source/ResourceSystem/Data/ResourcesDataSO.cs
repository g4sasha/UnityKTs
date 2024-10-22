using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "NewResourcesData", menuName = "ResourceSystem/ResourcesData")]
    public class ResourcesDataSO : ScriptableObject
    {
        [field: SerializeField]
        public List<ResourcesViewData> ResourcesData { get; private set; }
    }
}
