using Crombievents.Models;
using Crombievents.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crombievents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            return Ok(_eventService.GetAllEvents());
        }

        [HttpGet("{id}")]
        public ActionResult<Event> GetEventByID(string id)
        {
            var response = _eventService.GetEventByID(id);
            if (response == null)
            {
            return NotFound();
        }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Event> CreateEvent([FromBody] Event newEvent)
        {
            var createdEvent = _eventService.CreateEvent(newEvent);
            return CreatedAtAction(nameof(GetEventByID), new { id = createdEvent.EventID }, createdEvent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent([FromBody] Event updatedEvent)
        {
            var result = _eventService.UpdateEvent(updatedEvent);
            if (result == "Update failed")
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(string id)
        {
            var result = _eventService.DeleteEvent(id);
            if (result == "Delete failed")
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}