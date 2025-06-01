using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Application.DTOs;
using DigiMoviezClone.Application.Services;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigiMoviezClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieRepository service)
        {
            service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
            var movies = await _service.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponseDto>> GetById(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMovieRequestDto movie)
        {
            // user auto mapper  to convert dto into domain
            await _service.AddAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.Title }, movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieResponseDto>> Update(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            await _service.UpdateAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieResponseDto>> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}