using CommentActivityLog.Domain.Enums;

namespace CommentActivityLog.Application.DTOs.ActivityLog;

public class ActivityLogDto
{
    public DateTime? from_date { get; set; }
    public DateTime? to_date { get; set; }
    public string? user_name { get; set; }
    public ActionEnum? action { get; set; }
}