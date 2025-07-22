using System.Security.Claims;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Domain.Entities.Comments;
using DigiMoviezClone.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    
    private readonly ICommentService _commentService ;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("create")]
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
    [HttpGet("movie/{movieId}/flat")]
    public async Task<IActionResult> GetFlat(long movieId)
    {
        var flatList = await _commentService.GetFlat(movieId);
        return Ok(flatList);
    }

    [HttpGet("movie/{movieId}/tree")]
    public async Task<IActionResult> GetTree(long movieId)
    {
        var treeList = await _commentService.GetTree(movieId);
        return Ok(treeList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var comment = await _commentService.GetCommentByIdAsync(id);
        if (comment == null)
            return NotFound(new { message = "Comment not found" });

        return Ok(comment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentService.GetAllCommentsAsync();
        return Ok(comments);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateCommentDto dto)
    {
        try
        {
            await _commentService.UpdateCommentAsync(id, dto.Text);
            return Ok(new { message = "Comment updated successfully" });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _commentService.DeleteCommentAsync(id);
            return Ok(new { message = "Comment deleted successfully" });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }

        }
}





