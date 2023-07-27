using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public interface IVenueRepository
    {
        IEnumerable<Venue> GetAll();
        Task<Venue> GetById(long id);
        int Add(Venue @venue);
        void Update(Venue @venue);
        void Delete(Venue @venue);
        bool VenueExists(long venueId);
    }
}
