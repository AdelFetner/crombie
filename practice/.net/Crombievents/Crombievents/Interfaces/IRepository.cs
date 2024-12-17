using System.Collections.Generic;

namespace Crombievents.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetEntities(string query);
        T SearchEntityByID(string query, string id);
        T CreateEntity(string query, T entity);
        string UpdateEntity(string query, T updatedEntity);
        string DeleteEntity(string query, string id);
    }
}