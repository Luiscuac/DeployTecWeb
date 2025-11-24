using Security.Models;

namespace Security.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animals>> GetAllAnimalsAsync();
        Task<Animals> GetAnimalByIdAsync(Guid id);
        Task CreateAnimalAsync(Animals animal);
        Task UpdateAnimalAsync(Animals animal);
        Task DeleteAnimalAsync(Guid id);
    }
}
