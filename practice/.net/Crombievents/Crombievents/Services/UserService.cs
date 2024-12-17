using Crombievents.Interfaces;
using Crombievents.Models;

namespace Crombievents.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT * FROM Users";
            return _userRepository.GetEntities(query);
        }

        public User GetUserById(string id)
        {
            string query = "SELECT * FROM Users WHERE UserID = @id";
            return _userRepository.SearchEntityByID(query, id);
        }

        public User CreateUser(User newUser)
        {
            string query = @"
                INSERT INTO Users (UserID, Name, Email, Phone, RegisterDate) 
                VALUES (@UserID, @Name, @Email, @Phone, @RegisterDate);
                SELECT * FROM Users where UserId = @UserID";
            return _userRepository.CreateEntity(query, newUser);
        }

        public string UpdateUser(User updatedUser)
        {
            string query = @"
                UPDATE Users 
                SET Name = @Name, Email = @Email, Phone = @Phone, RegisterDate = @RegisterDate
                WHERE UserID = @UserID";
            return _userRepository.UpdateEntity(query, updatedUser);
        }

        public string DeleteUser(string id)
        {
            string query = "DELETE FROM Users WHERE UserID = @id";
            return _userRepository.DeleteEntity(query, id);
        }
    }
}
