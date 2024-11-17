using BookLibrary.DTOs;

namespace BookLibrary.Repo.BookRepo
{
    public interface IBookRepo
    {
        IEnumerable<BookDTO> GetAllBooks();

        BookDTO GetById(int id);

        void AddedBook(BookDTO bookDTO);
        void UpdateBook(BookDTO bookDTO,int id);
        void DeleteBook(int id);
    }
}
