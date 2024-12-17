using Crombievents.Data;
using Crombievents.Interfaces;
using Dapper;

namespace Crombievents.Repository
{
    public class ReportRepository<T> : IReportRepository<T>
    {
        private readonly DapperContext _context;

        public ReportRepository(DapperContext context)
        {
            _context = context;
        }

        public List<T> ExecuteReportMultiple(string query)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<T>(query).ToList();
            }
        }
        public T ExecuteReportSimple(string query)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.QueryFirst<T>(query);
            }
        }
    }
}