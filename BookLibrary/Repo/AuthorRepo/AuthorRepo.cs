using BookLibrary.Data;
using BookLibrary.DTOs;
using BookLibrary.Models;

namespace BookLibrary.Repo.AuthorRepo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;
        public AuthorRepo(AppDbContext context) 
        {
           _context = context;
        }
        public void add(AuthorDTO authorDTO)
        {
            var author = new Author
            {
                Email = authorDTO.Email,
                Name = authorDTO.Name,
                Phone = authorDTO.Phone,
            };
            _context.authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.authors.FirstOrDefault(a => a.Id == id);
            _context.authors.Remove(author);
            _context.SaveChanges();
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            var author = _context.authors.Select(x=>new AuthorDTO
            {
                Email=x.Email,
                Phone=x.Phone,
                Name = x.Name,
            }).ToList();
            return author;
        }

        public AuthorDTO GetById(int id)
        {
            var author = _context.authors.FirstOrDefault(x => x.Id == id);
            return new AuthorDTO
            {
                Email = author.Email,
                Name = author.Name,
                Phone = author.Phone,
            };
        }

        public void Update(AuthorDTO authorDTO, int id)
        {
            var author = _context.authors.FirstOrDefault(x => x.Id == id);
            author.Email = authorDTO.Email;
            author.Phone = authorDTO.Phone;
            author.Name = authorDTO.Name;

            _context.authors.Update(author);
            _context.SaveChanges();
        }
    }
}
