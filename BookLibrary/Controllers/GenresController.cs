using BookLibrary.DTOs;
using BookLibrary.Repo.GenreRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepo _genreRepo;
        public GenresController(IGenreRepo genreRepo)
        {
            _genreRepo = genreRepo;
        }
        [HttpPost]
        public IActionResult AddGenre(GenreDTO genreDTO)
        {
            if (ModelState.IsValid)
            {
                _genreRepo.add(genreDTO);
                return Created();
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteGenre(int id) 
        {
            if (id == null)
            {
                return NotFound("this genre is not found");
            }
            _genreRepo.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllGenre()
        {
            var genre = _genreRepo.GetAll();
            if (genre == null)
            {
                return NotFound("there is no genres");
            }
            return Ok(genre);

        }
        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id) 
        {
           var genre =  _genreRepo.GetById(id);
            if(genre == null)
            {
                return NotFound("no genre for this id");
            }
            return Ok(genre);
        }
        [HttpPut]
        public IActionResult UpdateGenre(GenreDTO genreDTO, int id)
        {
            _genreRepo.Update(genreDTO, id);
            return Accepted("Updated");
        }
    }
}
