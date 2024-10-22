using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "NewResourcesData", menuName = "ResourceSystem/ResourcesData")]
    public class ResourcesDataSO : ScriptableObject
    {
        [field: SerializeField]
        public List<ResourcesData> ResourcesData { get; private set; }
    }
}
