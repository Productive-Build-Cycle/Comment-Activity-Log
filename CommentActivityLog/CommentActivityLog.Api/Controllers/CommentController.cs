using CommentActivityLog.Application.DTOs.Comment;
using CommentActivityLog.Application.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;

namespace CommentActivityLog.Api.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost()]
    public async Task<IActionResult> Create(InsertCommentDto comment)
    {
        var result = await _commentService.CreateAsync(comment);
        return Ok(result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentDto comment)
    {
        var result = await _commentService.UpdateAsync(comment);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _commentService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _commentService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("{taskId}")]
    public async Task<IActionResult> GetByTaskId(int taskId)
    {
        var result = await _commentService.GetAllByTaskIdAsync(taskId);
        return Ok(result);
    }
}