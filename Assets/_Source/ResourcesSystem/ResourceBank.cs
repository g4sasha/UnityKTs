using System;
using System.Collections.Generic;

namespace ResourceSystem
{
    public class ResourceBank
    {
        private const int START_RESOURCE_VALUE = 0;
        private Dictionary<ResourceType, Resource> _resources;

        public ResourceBank() => Initialize(); // Bad practice

        public void Initialize(Dictionary<ResourceType, Resource> resources = null)
        {
            _resources = resources ?? new Dictionary<ResourceType, Resource>();

            for (int i = 0; i < Enum.GetValues(typeof(ResourceType)).Length; i++)
            {
                var newResource = new Resource((ResourceType)i, START_RESOURCE_VALUE);
                _resources.Add((ResourceType)i, newResource);
            }
        }

        public int GetResourceAmount(ResourceType type)
        {
            if (_resources.ContainsKey(type))
            {
                return _resources[type].Amount;
            }

            throw new ArgumentException("Resource type doesn't exist");
        }

        public bool TryGetResourceAmount(ResourceType type, out int amount)
        {
            amount = 0;

            if (_resources.ContainsKey(type))
            {
                amount = _resources[type].Amount;
                return true;
            }

            return false;
        }
    }
}
