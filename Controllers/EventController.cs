using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagmentSystem.Api.Models;
using TicketManagmentSystem.Api.Models.Dto;
using TicketManagmentSystem.Api.Repository;

namespace TicketManagmentSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository) {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll();
            var dtoEvents = new List<EventDto>();
                var dtoEvent = events.Select(e => new EventDto()
                {
                    EventId = e.Eventid,
                    EventDescription = e.EventDescription,
                    EventName = e.EventName,
                    EventType = e.EventType?.EventTypeName ?? string.Empty,
                    Venue = e.Venue?.LocationName ?? string.Empty
                });
                return Ok(dtoEvent);
        }
        
        [HttpGet]
        public ActionResult<EventDto> GetById(long id)
        {
            var @event = _eventRepository.GetById(id);

            if(@event == null)
            {
                return NotFound();
            }

            var dtoEvent = new EventDto()
            {
                EventId = @event.Eventid,
                EventDescription = @event.EventDescription,
                EventName = @event.EventName,
                EventType = @event.EventType?.EventTypeName ?? string.Empty,
                Venue = @event.Venue?.LocationName ?? string.Empty
            };
            return Ok(dtoEvent);
        }
    }
}
