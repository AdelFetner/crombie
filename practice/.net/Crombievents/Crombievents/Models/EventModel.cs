using System.Linq.Expressions;

namespace Crombievents.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; }
        public int MaxCapacity { get; set; }

        // finishing to understand how navigation props work  
        public int OrganizerID { get; set; }
    }
}