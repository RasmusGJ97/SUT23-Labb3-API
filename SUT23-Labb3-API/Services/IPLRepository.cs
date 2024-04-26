using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SUT23_Labb3_API.Data;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Services
{
    public class IPLRepository : ILabb3<InterestPersonLink>
    {
        private AppDbContext _appContext;
        public IPLRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<InterestPersonLink> Add(InterestPersonLink newEntity)
        {
            var result = await _appContext.InterestPersonLinks.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<InterestPersonLink>> GetAll()
        {
            return await _appContext.InterestPersonLinks
                .Include(p => p.Persons).Include(i => i.Interests).Include(l => l.Links).ToListAsync();
        }

        public async Task<List<InterestPersonLink>> GetSpecific(int id)
        {
            return await _appContext.InterestPersonLinks
                .Include(p => p.Persons).Include(i => i.Interests).Include(l => l.Links).Where(p => p.PersonId == id).ToListAsync();
        }
    }
}
