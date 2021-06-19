using System.Collections.Generic;

namespace BuildingBlock.RavenDB.Services
{
    public interface IRavenDataBase
    {
        void Update<T>(string objID,T obj) where T : class, new();

        void Delete(string objID);

        void Create(object obj);

        T LoadSingleEntry<T>(string objID) where T : class, new();

        List<T> LoadQuerying<T>(string Name) where T : class, new();
    }
}
