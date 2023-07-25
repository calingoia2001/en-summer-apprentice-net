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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _mapper.Map<List<OrderDto>>(_orderRepository.GetAll());
            return Ok(orders);
        }

        [HttpGet]
        public ActionResult<OrderDto> GetById(long id)
        {
            var @order = _mapper.Map<OrderDto>(_orderRepository.GetById(id));

            if (@order == null)
            {
                return NotFound();
            }

            return Ok(@order);
        }
    }
}
