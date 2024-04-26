using Microsoft.EntityFrameworkCore;
using SUT23_Labb3_API.Data;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Services
{
    public class PersonRepository : ILabb3<Person>
    {
        private AppDbContext _appContext;
        public PersonRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Person> Add(Person newEntity)
        {
            var result = await _appContext.Persons.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appContext.Persons.ToListAsync();
        }

        public async Task<List<Person>> GetSpecific(int id)
        {
            return await _appContext.Persons.Where(p => p.PersonId == id).ToListAsync();
        }
    }
}
