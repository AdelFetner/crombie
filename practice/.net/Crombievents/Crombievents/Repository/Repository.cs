using Crombievents.Data;
using Crombievents.Interfaces;

namespace Crombievents.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly DapperContext _context;

        public Repository(DapperContext context)
        {
            _context = context;
        }

        public List<T> GetEntities(string query)
        {
            return _context.GetEntities<T>(query);
        }

        public T SearchEntityByID(string query, string id)
        {
            return _context.SearchEntityByID<T>(query, id);
        }

        public T CreateEntity(string query, T entity)
        {
            return _context.CreateEntity<T>(query, entity);
        }

        public string UpdateEntity(string query, T updatedEntity)
        {
            return _context.UpdateEntity(query, updatedEntity);
        }

        public string DeleteEntity(string query, string id)
        {
            return _context.DeleteEntity(query, id);
        }
    }
}
