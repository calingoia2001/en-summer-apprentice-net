using AutoMapper;
using TicketManagmentSystem.Api.Models;
using TicketManagmentSystem.Api.Models.Dto;

namespace TicketManagmentSystem.Api.Helper
{
    public class VenueProfile : Profile
    {
        public VenueProfile() 
        {
            CreateMap<Venue, VenueDto>().ReverseMap();
        }
    }
}
