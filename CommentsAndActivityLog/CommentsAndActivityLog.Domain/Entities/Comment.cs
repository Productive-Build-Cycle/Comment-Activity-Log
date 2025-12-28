namespace CommentsAndActivityLog.Domain.Entities;

public class Comment
{
    public Comment()
    {
        ActivitiyLogList = new List<ActivityLog>();
    }
    public int Id { get; set; }
    public string Content { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<ActivityLog> ActivitiyLogList { get; set; }
}