using System.ComponentModel.DataAnnotations;

namespace BookLibrary.DTOs
{
    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }

        public List<BookDTO>? bookDTOs { get; set; } = new List<BookDTO>();
    }
}
