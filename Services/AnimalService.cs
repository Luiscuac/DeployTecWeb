using Security.Models;
using Security.Models.DTOS;
using Security.Repositories;

namespace Security.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
       
        public async Task<Animals> CreateAnimalAsync(CreateAnimalDto animal)
        {
            var Animal=new Animals
            {
                Id = Guid.NewGuid(),
                Name = animal.Name,
                Species = animal.Species,
                Age = animal.Age
            };
            await _animalRepository.CreateAnimalAsync(Animal);
            return Animal;
        }

        public async Task DeleteAnimalAsync(Guid id)
        {
            Animals? animal = _animalRepository.GetAnimalByIdAsync(id).Result;
            if (animal == null)
            {
                throw new Exception("Animal not found");
            }
            await _animalRepository.DeleteAnimalAsync(id);  
        }

        public async Task<IEnumerable<Animals>> GetAllAnimalsAsync()
        {
            return await  _animalRepository.GetAllAnimalsAsync();
        }

        public async Task<Animals> GetAnimalByIdAsync(Guid id)
        {
             return await _animalRepository.GetAnimalByIdAsync(id);
        }

        public async Task<Animals> UpdateAnimalAsync(UpdateAnimalDto animal, Guid id)
        {
            Animals? animals = await GetAnimalByIdAsync(id);
            if (animals == null)
            {
                throw new Exception("Animal not found");
            }
            animals.Name = animal.Name;
            animals.Species = animal.Species;
            animals.Age = animal.Age;
            await _animalRepository.UpdateAnimalAsync(animals);
            return animals;
        }
    }
}
