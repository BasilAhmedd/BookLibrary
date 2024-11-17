using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
