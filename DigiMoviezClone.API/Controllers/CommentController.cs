using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CommentDto commentDto)
    {
        await _commentService.AddCommentAsync(commentDto);
        return Ok(new { message = "Comment added successfully" });
    }

    [HttpGet("movie/{movieId}")]
    public async Task<IActionResult> GetByMovie(long movieId)
    {
        var comments = await _commentService.GetCommentsByMovieIdAsync(movieId);
        return Ok(comments);
    }
}
