using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public record CreateAnimalDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
