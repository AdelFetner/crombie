using Crombievents.Interfaces;
using Crombievents.Models;

namespace Crombievents.Services
{
    public class EventService
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<Event> GetAllEvents()
        {
            string query = "SELECT * FROM Events";
            return _eventRepository.GetEntities(query);
        }

        public Event GetEventByID(string id)
        {
            string query = "SELECT * FROM Events WHERE EventID = @id";
            return _eventRepository.SearchEntityByID(query, id);
        }

        public Event CreateEvent(Event newEvent)
        {
            string query = @"
                INSERT INTO Events (EventID, EventName, Date, Time, Location, MaxCapacity, OrganizerID) 
                VALUES (@EventID, @EventName, @Date, @Time, @Location, @MaxCapacity, @OrganizerID);
                SELECT * FROM Events WHERE EventID = @EventID";
            return _eventRepository.CreateEntity(query, newEvent);
        }

        public string UpdateEvent(Event updatedEvent)
        {
            string query = @"
                UPDATE Events 
                SET EventName = @EventName, Date = @Date, Time = @Time, Location = @Location, MaxCapacity = @MaxCapacity, OrganizerID = @OrganizerID
                WHERE EventID = @EventID";
            return _eventRepository.UpdateEntity(query, updatedEvent);
        }

        public string DeleteEvent(string id)
        {
            string query = "DELETE FROM Events WHERE EventID = @id";
            return _eventRepository.DeleteEntity(query, id);
        }
    }
}
