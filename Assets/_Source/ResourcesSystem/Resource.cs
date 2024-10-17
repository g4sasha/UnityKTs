using UnityEngine;

namespace ResourceSystem
{
    public class Resource
    {
        public ResourceType Type { get; private set; }

        public int Amount
        {
            get => _amount;
            set => _amount = Mathf.Max(value, 0);
        }

        private int _amount;

        public Resource(ResourceType type, int amount)
        {
            Amount = amount;
            Type = type;
        }
    }
}
