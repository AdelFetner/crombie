using Crombievents.Data;
using System.Collections.Generic;

namespace Crombievents.Services
{
    public class ReportService
    {
        private readonly ReportContext _reportContext;

        public ReportService(ReportContext reportContext)
        {
            _reportContext = reportContext;
        }

        public List<object> GetEventsWithMostAttendees()
        {
            // sql server doesnt have limit, top it's the alternative of mysql's limit
            string query = @"
                SELECT TOP 1 WITH TIES e.EventID, e.EventName AS EventName, e.Date AS EventDate, e.Location AS EventLocation, e.MaxCapacity AS EventCapacity, e.OrganizerID, COUNT(a.AttendanceID) AS AttendeeCount
                FROM Events e
                JOIN Attendance a ON e.EventID = a.EventID
                GROUP BY e.EventID, e.EventName, e.Date, e.Location, e.MaxCapacity, e.OrganizerID
                ORDER BY COUNT(a.AttendanceID) DESC";

            return _reportContext.GetEntities<object>(query);
        }

        public object GetTotalIncomeByEvent(int eventId)
        {
            string query = @"
                SELECT e.EventID, e.EventName, SUM(p.Amount) AS TotalIncome
                FROM Events e
                JOIN Reservations r ON e.EventName = r.EventName AND e.Date = r.EventDate
                JOIN Payments p ON r.ReservationID = p.ReservationID
                WHERE e.EventID = @eventId
                GROUP BY e.EventID, e.EventName";

            return _reportContext.SearchEntityWithParams<object>(query, new { eventId });
        }

        public List<object> GetEventsByOrganizer(int organizerID)
        {
            string query = @"
                SELECT e.EventID, e.EventName, e.Date, e.Time, e.Location, e.MaxCapacity
                FROM Events e
                JOIN Employees emp ON e.OrganizerID = emp.EmployeeID
                JOIN EmployeeTypes et ON emp.EmployeeTypeID = et.EmployeeTypeID
                WHERE emp.EmployeeID = @organizerID AND et.TypeName = 'Organizer'";

            return _reportContext.SearchEntitiesWithParams<object>(query, new { organizerID });
        }

        public List<object> GetUsersWithMostReservations()
        {
            string query = @"
                SELECT TOP 1 WITH TIES r.UserName, COUNT(r.ReservationID) AS ReservationCount
                FROM Reservations r
                GROUP BY r.UserName
                ORDER BY ReservationCount DESC";

            return _reportContext.GetEntities<object>(query);
        }

        public List<object> GetUpcomingEventsByLocation(string location)
        {
            string query = @"
                SELECT e.EventID, e.EventName, e.Date, e.Time, e.Location
                FROM Events e
                WHERE e.Location = @location AND e.Date >= GETDATE()
                ORDER BY e.Date, e.Time";

            return _reportContext.SearchEntitiesWithParams<object>(query, new { location });
        }

        public List<object> GetPaymentsReportByMonth(int month, int year)
        {
            string query = @"
                SELECT p.PaymentID, p.ReservationID, p.Amount, p.PaymentDate, p.PaymentMethod
                FROM Payments p
                WHERE MONTH(p.PaymentDate) = @month AND YEAR(p.PaymentDate) = @year";

            return _reportContext.SearchEntitiesWithParams<object>(query, new { month, year });
        }

        public List<object> GetEventAndReservationHistoryByUser(int userId)
        {
            string query = @"
                SELECT r.UserName, r.EventName, r.EventDate, r.TicketQuantity, r.ReservationDate
                FROM Reservations r
                JOIN Users u ON r.UserEmail = u.Email
                WHERE u.UserID = @userId";

            return _reportContext.SearchEntitiesWithParams<object>(query, new { userId });
        }

        public List<object> GetEmployeesWithMostSales()
        {
            string query = @"
                SELECT TOP 1 WITH TIES emp.EmployeeID, emp.Name, COUNT(ts.SaleID) AS SalesCount, SUM(ts.TotalSale) AS TotalSales
                FROM Employees emp
                JOIN TicketSales ts ON emp.EmployeeID = ts.EmployeeID
                GROUP BY emp.EmployeeID, emp.Name
                ORDER BY TotalSales DESC";

            return _reportContext.GetEntities<object>(query);
        }
    }
}