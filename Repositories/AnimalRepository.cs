using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;

namespace Security.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _db;
        public AnimalRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task CreateAnimalAsync(Animals animal)
        {
            await _db.Animals.AddAsync(animal);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAnimalAsync(Guid id)
        {
            _db.Animals.Remove(await GetAnimalByIdAsync(id));
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Animals>> GetAllAnimalsAsync()
        {
            return await _db.Animals.ToListAsync();
        }

        public async Task<Animals> GetAnimalByIdAsync(Guid id)
        {
            return await _db.Animals.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAnimalAsync(Animals animal)
        {
            _db.Animals.Update(animal);
            await _db.SaveChangesAsync();
        }
    }
}
