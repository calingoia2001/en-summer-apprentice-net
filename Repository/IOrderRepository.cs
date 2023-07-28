using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetById(long id);
        int Add(Order @order);
        Task Update(Order @order);
        Task Delete(Order @order);
        bool OrderExists(long orderId);
    }
}
