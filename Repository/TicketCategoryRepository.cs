using Microsoft.EntityFrameworkCore;
using TicketManagmentSystem.Api.Exceptions;
using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly ProjectDataBaseSpringContext _dbContext;
        public TicketCategoryRepository()
        {
            _dbContext = new ProjectDataBaseSpringContext();
        }

        public int Add(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TicketCategory>> GetAllAsync()
        {
            var ticketCategories = await _dbContext.TicketCategories.ToListAsync();
            return ticketCategories;
        }

        public async Task<TicketCategory> GetById(long id)
        {
            var @ticketCategories = await _dbContext.TicketCategories.Where(e => e.TicketCategoryid == id).FirstOrDefaultAsync();
            if (ticketCategories == null)
            {
                throw new EntityNotFoundException(id, nameof(TicketCategory));
            }
            return ticketCategories;
        }

        public bool TicketCategoryExists(long ticketCategoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }
    }
}
