using System.ComponentModel.DataAnnotations;

namespace BookLibrary.DTOs
{
    public class AuthorDTO
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Enter number")]
        public string Phone { get; set; }
    }
}
