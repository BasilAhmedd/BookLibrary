namespace BookLibrary.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }

        public List<int> GenreIds { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<string>? Genres { get; set; } = new List<string>();
        public List<string>? Authors { get; set; }= new List<string>();
    }
}
