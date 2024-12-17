using System.Collections.Generic;

namespace Crombievents.Interfaces
{
    public interface IReportRepository<T>
    {
        List<T> ExecuteReportMultiple(string query);
        T ExecuteReportSimple(string query);
    }
}