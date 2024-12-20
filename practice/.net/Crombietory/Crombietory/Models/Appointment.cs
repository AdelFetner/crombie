namespace Crombietory.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }

        public DateTime date { get; set; }
        public bool isActive { get; set; }
    }
}
