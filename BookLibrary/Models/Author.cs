using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<Book> books { get; set;}
    }
}
