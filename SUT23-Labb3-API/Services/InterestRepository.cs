using Microsoft.EntityFrameworkCore;
using SUT23_Labb3_API.Data;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Services
{
    public class InterestRepository : ILabb3<Interest>
    {
        private AppDbContext _appContext;
        public InterestRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _appContext.Interests.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appContext.Interests.ToListAsync();
        }

        public async Task<List<Interest>> GetSpecific(int id)
        {
            return await _appContext.Interests.Where(p => p.InterestId == id).ToListAsync();
        }
    }
}
