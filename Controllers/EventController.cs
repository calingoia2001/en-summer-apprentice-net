﻿using AutoMapper;
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
        
        public EventController(IEventRepository eventRepository, IMapper mapper) {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<EventDto>))]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _mapper.Map<List<EventDto>>(_eventRepository.GetAll());
            return Ok(events);
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(EventDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<EventDto>> GetById(long id)
        {
            try
            {
                var @event = _mapper.Map<EventDto>(await _eventRepository.GetById(id));

                if (@event == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(@event);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            if (!_eventRepository.EventExists(id))
            {
                return NotFound();
            }

            var eventEntity = await _eventRepository.GetById(id);
            
            if (eventEntity == null)
            {
                return NotFound();
            }

            _eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}
