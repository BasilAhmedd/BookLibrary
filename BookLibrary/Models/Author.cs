using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Enter number")]
        public string Phone { get; set; }

        public ICollection<Book> books { get; set;}
    }
}
