using CommentActivityLog.Application.DTOs.Comment;

namespace CommentActivityLog.Application.Service;

public interface ICommentService
{
    Task CreateAsync(InsertCommentDto commentDto);
    Task UpdateAsync(UpdateCommentDto commentDto);
    Task DeleteAsync(int id);
    Task<CommentDto> GetByIdAsync(int id);
    Task<List<CommentDto>> GetAllByTaskIdAsync(int taskId);
}