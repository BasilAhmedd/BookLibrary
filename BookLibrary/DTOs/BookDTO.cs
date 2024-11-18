using System.ComponentModel.DataAnnotations;

namespace BookLibrary.DTOs
{
    public class BookDTO
    {
        [Required]
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }
        // add , update
        public List<int> GenreIds { get; set; }
        public List<int> AuthorIds { get; set; }
        // get , get all
        public List<GenreDTO>? Genres { get; set; } = new List<GenreDTO>();
        public List<AuthorDTO>? Authors { get; set; }= new List<AuthorDTO>();
    }
}
