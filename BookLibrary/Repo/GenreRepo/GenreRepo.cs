using BookLibrary.Data;
using BookLibrary.DTOs;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Repo.GenreRepo
{
    public class GenreRepo : IGenreRepo
    {
        private readonly AppDbContext _context;
        public GenreRepo(AppDbContext context)
        {
            _context = context;
        }
        public void add(GenreDTO genreDTO)
        {
            var genre = new Genre
            {
                Name = genreDTO.Name,
                books = genreDTO.bookDTOs.Select(x => new Book
                {
                    Title = x.Title,
                    PublishedYear = x.PublishedYear,
                }).ToList(),
            };

            _context.genres.Add(genre);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var genress=_context.genres.FirstOrDefault(x => x.Id == id);
            _context.genres.Remove(genress);
            _context.SaveChanges();
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            var genre = _context.genres.Include(x => x.books).Select(
                y => new GenreDTO
                {
                    Name = y.Name,
                    bookDTOs = y.books.Select(u => new BookDTO
                    {
                        Title = u.Title,
                        PublishedYear = u.PublishedYear,
                    }).ToList()

                }).ToList();
            return genre;
        }

        public GenreDTO GetById(int id)
        {
            var genre = _context.genres.FirstOrDefault(x=>x.Id==id);
            return new GenreDTO
            {
                Name = genre.Name
            };
        }

        public void Update(GenreDTO genreDTO, int id)
        {
            var genre = _context.genres.FirstOrDefault(x => x.Id == id);
            genre.Name = genreDTO.Name;
            _context.Update(genre);
            _context.SaveChanges();
        }
    }
}
