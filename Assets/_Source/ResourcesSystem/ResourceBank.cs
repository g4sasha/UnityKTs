using System;
using System.Collections.Generic;

namespace ResourceSystem
{
    public class ResourceBank
    {
        private const int START_RESOURCE_VALUE = 0;

        public static ResourceBank Instance
        {
            get
            {
                _instance ??= new ResourceBank();
                return _instance;
            }
        }

        private static ResourceBank _instance;
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

        public void AddResource(ResourceType type, int amount)
        {
            if (_resources.ContainsKey(type))
            {
                _resources.Add(type, new Resource(type, _resources[type].Amount + amount));
            }
            else
            {
                throw new ArgumentException("Resource type doesn't exist");
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
