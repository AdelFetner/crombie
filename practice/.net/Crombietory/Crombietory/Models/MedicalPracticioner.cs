namespace Crombietory.Models
{
    public class MedicalPracticioner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public bool Disponibility { get; set; }
    }
}
