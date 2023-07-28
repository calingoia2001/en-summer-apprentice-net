using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketManagmentSystem.Api.Exceptions;
using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProjectDataBaseSpringContext _dbContext;
        public OrderRepository()
        {
            _dbContext = new ProjectDataBaseSpringContext();
        }

        // todo
        public int Add(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Order @order)
        {
            _dbContext.Remove(@order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetById(long id)
        {
            var @order = await _dbContext.Orders.Where(o => o.Orderid == id).FirstOrDefaultAsync();
            if (@order == null)
            {
                throw new EntityNotFoundException(id, nameof(Order));
            }
            return @order;
        }

        public async Task Update(Order @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public bool OrderExists(long orderId)
        {
            return _dbContext.Orders.Any(o => o.Orderid == orderId);
        }
    }
}
