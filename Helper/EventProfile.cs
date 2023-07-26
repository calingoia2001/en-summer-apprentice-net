using AutoMapper;
using TicketManagmentSystem.Api.Models.Dto;
using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Helper
{
    public class EventProfile : Profile
    {
        public EventProfile () {
            CreateMap<Event, EventDto>();
            CreateMap<Event, EventPatchDto>().ReverseMap(); // .reverseMap -> mapeaza invers din eventdto in event
        }

    }
}
