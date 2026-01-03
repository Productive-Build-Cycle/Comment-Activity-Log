using CommentActivityLog.Application.DTOs.Comment;
using CommentActivityLog.Domain.Common;

namespace CommentActivityLog.Application.Service;

public interface ICommentService
{
    Task<Result> CreateAsync(InsertCommentDto commentDto);
    Task<Result> UpdateAsync(UpdateCommentDto commentDto);
    Task<Result> DeleteAsync(int id);
    Task<Result<CommentDto>> GetByIdAsync(int id);
    Task<Result<List<CommentDto>>> GetAllByTaskIdAsync(int taskId);
}