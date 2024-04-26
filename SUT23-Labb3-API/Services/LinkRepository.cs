using Microsoft.EntityFrameworkCore;
using SUT23_Labb3_API.Data;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Services
{
    public class LinkRepository : ILabb3<Link>
    {
        private AppDbContext _appContext;
        public LinkRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<Link> Add(Link newEntity)
        {
            var result = await _appContext.Links.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _appContext.Links.ToListAsync();
        }

        public async Task<List<Link>> GetSpecific(int id)
        {
            return await _appContext.Links.Where(p => p.LinkId == id).ToListAsync();
        }
    }
}
