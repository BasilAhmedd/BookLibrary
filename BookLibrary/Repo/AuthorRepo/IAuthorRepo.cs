using BookLibrary.DTOs;

namespace BookLibrary.Repo.AuthorRepo
{
    public interface IAuthorRepo
    {
        AuthorDTO GetById(int id);

        void Update(AuthorDTO authorDTO,int id);
        void Delete(int id);
        IEnumerable<AuthorDTO> GetAll();
        void add(AuthorDTO authorDTO);
    }
}
