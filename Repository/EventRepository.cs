using Microsoft.EntityFrameworkCore;
using TicketManagmentSystem.Api.Exceptions;
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

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events.Include(x => x.Venue).ToList();
            return events;
        }

        public async Task<Event> GetById(long id)
        {
            var @event = await _dbContext.Events.Where(e => e.Eventid == id).FirstOrDefaultAsync();
            if(@event == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }
            return @event;
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public bool EventExists(long eventId)
        {
            return _dbContext.Events.Any(e => e.Eventid == eventId);
        }
    }
}
