namespace Crombievents.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }
        public int EmployeeID { get; set; }

        // Navigation property
        public Employee Employee { get; set; }
    }
}