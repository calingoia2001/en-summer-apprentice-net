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

        public async Task Delete(Event @event)
        {
            _dbContext.Remove(@event);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var events = await _dbContext.Events.Include(x => x.Venue).ToListAsync();
            return events;
        }

        public async Task<Event> GetById(long id)
        {
            var @event = await _dbContext.Events.Include(x => x.Venue).Where(e => e.Eventid == id).FirstOrDefaultAsync();
            if(@event == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }
            return @event;
        }

        public async Task Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public bool EventExists(long eventId)
        {
            return _dbContext.Events.Any(e => e.Eventid == eventId);
        }
    }
}
