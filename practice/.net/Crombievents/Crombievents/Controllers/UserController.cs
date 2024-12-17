using Crombievents.Models; // Assuming you have a User model
using Crombievents.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crombievents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserByID(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            var createdUser = _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserByID), new { id = createdUser.UserID }, createdUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            var result = _userService.UpdateUser(user);
            if (result == "Update failed")
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var result = _userService.DeleteUser(id);
            if (result == "Delete failed")
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
