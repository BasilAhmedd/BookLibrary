using System.ComponentModel.DataAnnotations;

namespace BookLibrary.DTOs
{
    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
