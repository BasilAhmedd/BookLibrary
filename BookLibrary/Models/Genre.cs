using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Book> books { get; set; }

    }
}
