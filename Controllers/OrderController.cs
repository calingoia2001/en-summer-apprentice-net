using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagmentSystem.Api.Models.Dto;
using TicketManagmentSystem.Api.Repository;

namespace TicketManagmentSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();
            var dtoOrders = new List<OrderDto>();
            var dtoOrder = orders.Select(o => new OrderDto()
            {
                OrderID = o.Orderid,
                NumberOfTickets = (int)o.NumberOfTickets
            });
            return Ok(dtoOrder);
        }
    }
}
