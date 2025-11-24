using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public record UpdateAnimalDto
    {
        
        public string Name { get; set; }
 
        public string Species { get; set; }
     
        public int Age { get; set; }
    }
}
