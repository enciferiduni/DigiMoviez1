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
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("create")]
    [HttpPost("movie/{movieId}/create")]
    public async Task<IActionResult> CreateOrReply(long? movieId = null, [FromBody] CommentDto commentDto = null)
    {
        var userId = "user-" + Guid.NewGuid().ToString("N")[..8];

        try
        {
            if (commentDto.ParentCommentId == null)
            {
                // Create a new comment
                if (movieId.HasValue)
                {
                    // Override movieId to ensure consistency when provided in route
                    commentDto.MovieId = movieId.Value;
                }
                
                await _commentService.AddCommentAsync(commentDto, userId);
                return Ok(new { message = "Comment added successfully" });
            }
            else
            {
                // Add a reply
                if (movieId.HasValue)
                {
                    // Use movie validation when movieId is provided in route
                    var reply = await _commentService.AddReplyWithMovieValidationAsync(new CreateReplyDto
                    {
                        Text = commentDto.Text,
                        ParentCommentId = commentDto.ParentCommentId.Value
                    }, movieId.Value, userId);

                    return Ok(new { message = "Reply added successfully", reply });
                }
                else
                {
                    // Use general approach when no movieId in route
                    var reply = await _commentService.AddReplyAsync(new CreateReplyDto
                    {
                        Text = commentDto.Text,
                        ParentCommentId = commentDto.ParentCommentId.Value
                    }, userId);

                    return Ok(new { message = "Reply added successfully", reply });
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("movie/{movieId}")]
    public async Task<IActionResult> GetByMovie(long movieId)
    {
        var comments = await _commentService.GetCommentsByMovieIdAsync(movieId);
        return Ok(comments);
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





