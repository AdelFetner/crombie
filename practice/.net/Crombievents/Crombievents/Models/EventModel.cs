namespace Crombievents.Models
{
    public class EventModel
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Place { get; set; }
        public int MaxCapacity { get; set; }
        public int OrganizerID { get; set; }
    }
}
