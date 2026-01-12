using CommentActivityLog.Domain.Enums;

namespace CommentActivityLog.Domain.Entities;

public class ActivityLogEntity
{
    public int Id { get; set; }
    public ActionEnum Action { get; set; }
    public DateTime Created_at { get; set; }
    public int CommentId { get; set; }
    public CommentEntity Comment { get; set; }
}