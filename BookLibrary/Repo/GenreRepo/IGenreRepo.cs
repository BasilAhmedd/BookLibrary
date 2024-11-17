using BookLibrary.DTOs;

namespace BookLibrary.Repo.GenreRepo
{
    public interface IGenreRepo
    {
        GenreDTO GetById(int id);

        void Update(GenreDTO genreDTO, int id);
        void Delete(int id);
        IEnumerable<GenreDTO> GetAll();
        void add(GenreDTO genreDTO);
    }
}
