using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;
        
        public OrderController(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<OrderDto>))]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            var orders = _mapper.Map<List<OrderDto>>(await _orderRepository.GetAllAsync());
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
            var ticketCategoryEntity = await _ticketCategoryRepository.GetById(orderPatch.TicketCategoryid);

            if (orderEntity == null)
            {
                return NotFound();
            }

            orderEntity.TotalPrice = orderPatch.NumberOfTickets * ticketCategoryEntity.Price;
            _mapper.Map(orderPatch, orderEntity);
            await _orderRepository.Update(orderEntity);

            var orderResponse = _mapper.Map<OrderDto>(orderEntity);

            return new ContentResult()
            {
                Content = JsonSerializer.Serialize(orderResponse),
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            await _orderRepository.Delete(orderEntity);
            return NoContent();
        }
    }
}
