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

        public int Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }

        public Order GetById(long id)
        {
            var @order = _dbContext.Orders.Where(o => o.Orderid == id).FirstOrDefault();
            return @order;
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
