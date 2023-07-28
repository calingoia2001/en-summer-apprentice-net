using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetById(long id);
        int Add(Event @event);
        Task Update(Event @event);
        Task Delete(Event @event);
        bool EventExists(long eventId);
    }
}
