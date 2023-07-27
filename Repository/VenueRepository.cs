using Microsoft.EntityFrameworkCore;
using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public class VenueRepository : IVenueRepository
    {
        private readonly ProjectDataBaseSpringContext _dbContext;
        public VenueRepository()
        {
            _dbContext = new ProjectDataBaseSpringContext();
        }

        public int Add(Venue venue)
        {
            throw new NotImplementedException();
        }

        public void Delete(Venue venue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venue> GetAll()
        {
            var venues = _dbContext.Venues;
            return venues;
        }

        public Task<Venue> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Venue venue)
        {
            throw new NotImplementedException();
        }

        public bool VenueExists(long venueId)
        {
            throw new NotImplementedException();
        }
    }
}
