namespace Crombievents.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public User(int userID, string name, string email, string phone, DateTime registerDate)
        {
            UserID = userID;
            Name = name;
            Email = email;
            Phone = phone;
            RegisterDate = registerDate;
        }

        public User()
        {
        }
    }
}
