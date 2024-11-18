using BookLibrary.DTOs;
using BookLibrary.Repo.AuthorRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _authorRepo;
        public AuthorsController(IAuthorRepo _authorRepo)
        {}
        [HttpPost]
        public IActionResult AddAuthor(AuthorDTO authorDTO)
        {
            if (ModelState.IsValid)
            {
                _authorRepo.add(authorDTO);
                return Created();
            }
            return NotFound("no data found");
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id) 
        { 
            if (id == null)
            {
                return NotFound("no author with this id");
            }
            _authorRepo.Delete(id);
            return NoContent();


        }

        [HttpGet]

        public IActionResult GetAllAuthor() 
        {
            var author = _authorRepo.GetAll();
            if (author == null)
            {
                return NotFound("no authors exists");
            }
            return Ok(author);
        } 
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id) 
        {
            var author = _authorRepo.GetById(id);
            if (author == null)
            {
                return NotFound("no authors found for this Id");
            }
            return Ok(author);
        }

        [HttpPut]
        public IActionResult updateAuthor(AuthorDTO authorDTO,int id)
        {
            _authorRepo.Update(authorDTO,id);
            return Accepted();
        }
    }
}
