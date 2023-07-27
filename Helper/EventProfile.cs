using AutoMapper;
using TicketManagmentSystem.Api.Models.Dto;
using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Helper
{
    public class EventProfile : Profile
    {
        public EventProfile () {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();
        }
    }
}
