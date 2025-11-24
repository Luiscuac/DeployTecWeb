using Security.Models;
using Security.Models.DTOS;

namespace Security.Services
{
    public interface IAnimalService
    {
        Task<IEnumerable<Animals>> GetAllAnimalsAsync();
        Task<Animals> GetAnimalByIdAsync(Guid id);
        Task<Animals> CreateAnimalAsync(CreateAnimalDto animal);
        Task <Animals> UpdateAnimalAsync(UpdateAnimalDto animal, Guid id);
        Task DeleteAnimalAsync(Guid id);
    }
}
