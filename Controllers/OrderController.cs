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
        [ProducesResponseType(200, Type = typeof(List<OrderDto>))]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _mapper.Map<List<OrderDto>>(_orderRepository.GetAll());
            return Ok(orders);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<OrderDto>> GetById(long id)
        {
            var @order = _mapper.Map<OrderDto>(await _orderRepository.GetById(id));
            return Ok(@order);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderID);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(orderPatch, orderEntity);
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }
    }
}
