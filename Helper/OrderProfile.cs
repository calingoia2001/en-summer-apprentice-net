using AutoMapper;
using TicketManagmentSystem.Api.Models;
using TicketManagmentSystem.Api.Models.Dto;

namespace TicketManagmentSystem.Api.Helper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderPatchDto, Order>().ReverseMap();
        }
    }
}
