namespace NivelAccessDate_DBFirst
{
    public interface ICache
    {
        void Clear();
        T Get<T>(string key);
        bool IsSet(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Set(string key, object objectData, int? cacheTime = null);
    }
}