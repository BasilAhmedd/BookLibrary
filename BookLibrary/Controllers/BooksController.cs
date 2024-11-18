using BookLibrary.DTOs;
using BookLibrary.Repo.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;
        public BooksController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }
        [HttpPost]
        public IActionResult AddBook(BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.AddBookOnly(bookDTO);
                return Created();

            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult PostBookWithAuthorAndGenre(BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.AddedBook(bookDTO);
                return Created();

            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id) 
        {
            var book = _bookRepo.GetById(id);
            if(book == null)
            {
                return NotFound("No book for this Id");
            }
            return Ok(book);
        } 
        [HttpGet]
        public IActionResult GetAllBooks() 
        {
            var book = _bookRepo.GetAllBooks;
            if(book == null)
            {
                return NotFound("No books");
            }
            return Ok(book);
        }
        [HttpPut]
        public IActionResult UpdateBook(BookDTO bookDTO,int id) 
        { 
            _bookRepo.UpdateBook(bookDTO,id);
            return Accepted("Updated");
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id) 
        { 
            if(id == null)
            {
                return NotFound("You Must Enter an id");
            }
            _bookRepo.DeleteBook(id);
            return NoContent();
        }

    }
}
