using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EventController(IEventRepository eventRepository, IMapper mapper, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }
        

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<EventDto>))]
        public async Task<ActionResult<List<EventDto>>> GetAll()
        {
            var events = _mapper.Map<List<EventDto>>(await _eventRepository.GetAllAsync());
            return Ok(events);
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(EventDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<EventDto>> GetById(long id)
        {
            var @event = _mapper.Map<EventDto>(await _eventRepository.GetById(id));
            return Ok(@event);
        }
    
        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventID);
            if(eventEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(eventPatch, eventEntity);
            await _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            await _eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}
