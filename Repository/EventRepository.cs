using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ProjectDataBaseSpringContext _dbContext;
        public EventRepository() { 
            _dbContext = new ProjectDataBaseSpringContext();
        }
        int IEventRepository.Add(Event @event)
        {
            throw new NotImplementedException();
        }

        void IEventRepository.Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;
            return events;
        }

        public Event GetById(long id)
        {
            var @event = _dbContext.Events.Where(e => e.Eventid == id).FirstOrDefault();
            return @event;
        }

        void IEventRepository.Update(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
