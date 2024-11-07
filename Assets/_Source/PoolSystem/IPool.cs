namespace PoolSystem
{
    public interface IPool<T>
    {
        int Count { get; }
        void InitPool(T prefab, int initSize);
        T GetFromPool();
        void ReturnToPool(T element);
        T InstantiatePoolObject(T prefab);
    }
}
