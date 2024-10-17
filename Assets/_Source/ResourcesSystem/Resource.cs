namespace ResourceSystem
{
    public class Resource
    {
        public int Amount { get; private set; }
        public ResourceType Type { get; private set; }

        public Resource(ResourceType type, int amount)
        {
            Amount = amount;
            Type = type;
        }
    }
}
