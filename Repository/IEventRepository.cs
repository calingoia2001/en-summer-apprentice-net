using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event GetById(long id);
        int Add(Event @event);
        void Update(Event @event);
        void Delete(long id);
    }
}
