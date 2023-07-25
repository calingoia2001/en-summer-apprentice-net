using AutoMapper;
using TicketManagmentSystem.Api.Models;
using TicketManagmentSystem.Api.Models.Dto;

namespace TicketManagmentSystem.Api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
