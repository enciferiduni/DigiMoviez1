using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.API.DTOs.Movie;
using DigiMoviezClone.Application.Services;
using DigiMoviezClone.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DigiMoviezClone.Application.DTOs;
using DigiMoviezClone.Application.DTOs.Movie;
using DigiMoviezClone.Domain.Entities.Movies;
using DigiMoviezClone.Domain.Interfaces;

namespace DigiMoviezClone.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase, IBaseController<MovieResponseDto, MovieRequestDto>
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        public MovieController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponseDto>>> GetAll()
        {
            var movies = await _service.GetAll();
            var movieDtos = _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
            return Ok(movieDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponseDto>> GetById(long id)
        {
            var movie = await _service.GetById(id);
            var dto = _mapper.Map<MovieResponseDto>(movie);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<MovieResponseDto>> Create(MovieRequestDto request)
        {
            var movie = _mapper.Map<Movie>(request);
            var savedMovie = await _service.Create(movie);
            var responseDto = _mapper.Map<MovieResponseDto>(savedMovie);
            return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieResponseDto>> Update(long id, MovieRequestDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            var updatedMovie = await _service.Update(id, movie);
            var responseDto = _mapper.Map<MovieResponseDto>(updatedMovie);
            return Ok(responseDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieResponseDto>> Delete(long id)
        {
            var deletedMovie = await _service.Delete(id);
            var dto = _mapper.Map<MovieResponseDto>(deletedMovie);
            return Ok(dto);
        }
 
    }

 
}
