using CommentsAndActivityLog.Domain.Enums;

namespace CommentsAndActivityLog.Domain.Entities;

public class ActivityLog
{
    public int Id { get; set; }
    public ActionEnum Action { get; set; }
    public DateTime Created_at { get; set; }
    public int CommentId { get; set; }
    public Comment Comment { get; set; }
}