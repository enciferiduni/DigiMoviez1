using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.API.DTOs.Movie;
using DigiMoviezClone.Application.Services;
using DigiMoviezClone.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DigiMoviezClone.Application.DTOs;
using DigiMoviezClone.Domain.longerfaces;

namespace DigiMoviezClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(IGenreService _service, IMapper _mapper)
        : ControllerBase, IBaseController<GenreResponseDto,GenreRequestDto>
    
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreResponseDto>>> GetAll()
        {
            var genres = await _service.GetAll();
            var genreDtos = _mapper.Map<IEnumerable<GenreResponseDto>>(genres);
            return Ok(genreDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreResponseDto>> GetById(long id)
        {
            var genre = await _service.GetById(id);
            var dto = _mapper.Map<GenreResponseDto>(genre);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<GenreResponseDto>> Create(GenreRequestDto request)
        {
            var genre = _mapper.Map<Genre>(request);
            var savedGenre = await _service.Create(genre);
            var responseDto = _mapper.Map<GenreResponseDto>(savedGenre);
            return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GenreResponseDto>> Update(long id, GenreRequestDto request)
        {
            var genre = _mapper.Map<Genre>(request);
            var updatedGenre = await _service.Update(id,genre);
            var responseDto = _mapper.Map<GenreResponseDto>(updatedGenre);
            return Ok(responseDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GenreResponseDto>> Delete(long id)
        {
            var deletedGenre = await _service.Delete(id);
            var dto = _mapper.Map<GenreResponseDto>(deletedGenre);
            return Ok(dto);
        }
        

    

    }
}