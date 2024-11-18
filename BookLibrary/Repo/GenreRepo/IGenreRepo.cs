using BookLibrary.DTOs;

namespace BookLibrary.Repo.GenreRepo
{
    public interface IGenreRepo
    {
        GenreDTO GetById(int id);
        IEnumerable<GenreDTO> GetAll();
        void Update(GenreDTO genreDTO, int id);
        void Delete(int id);
        void add(GenreDTO genreDTO);
    }
}
