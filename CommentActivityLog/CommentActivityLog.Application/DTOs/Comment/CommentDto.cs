using CommentsAndActivityLog.Domain.Enums;

namespace CommentActivityLog.Application.DTOs.Comment;

public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public bool IsDelete { get; set; }
    public int TaskId { get; set; }
}