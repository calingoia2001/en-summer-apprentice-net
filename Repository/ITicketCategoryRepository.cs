using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public interface ITicketCategoryRepository
    {
        Task<IEnumerable<TicketCategory>> GetAllAsync();
        Task<TicketCategory> GetById(long id);
        int Add(TicketCategory ticketCategory);
        void Update(TicketCategory @ticketCategory);
        void Delete(TicketCategory ticketCategory);
        bool TicketCategoryExists(long ticketCategoryId);
    }
}
