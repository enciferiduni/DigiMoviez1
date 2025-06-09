using AutoMapper;
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
        private readonly IMapper _mapper;

        public MovieController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponseDto>>> GetAll()
        {
            var movies = await _service.findAllMovies();
            IEnumerable<MovieResponseDto> movieDtos = _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
            return Ok(movieDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponseDto>> GetById(int id)
        {
            var movie = await _service.findMovie(id);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieResponseDto>> Create(CreateMovieRequestDto movie)
        {
            Movie mappedMovie = _mapper.Map<CreateMovieRequestDto, Movie>(movie);
            Movie savedMovie = await _service.createMovie(mappedMovie);
            MovieResponseDto responseDto = _mapper.Map<MovieResponseDto>(savedMovie);
            return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieResponseDto>> Update(int id, UpdateMovieRequestDto movie)
        {
            Movie mappedMovie = _mapper.Map<UpdateMovieRequestDto, Movie>(movie);
            Movie updateMovie = await _service.UpdateMovie(id, mappedMovie);
            MovieResponseDto responseDto = _mapper.Map<MovieResponseDto>(updateMovie);
            return Ok(responseDto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieResponseDto>> Delete(int id)
        {
            Movie deleteMovie = await _service.DeleteMovie(id);
            MovieResponseDto deletedMovie = _mapper.Map<MovieResponseDto>(deleteMovie);
            return Ok(deletedMovie);
        }
    }
}