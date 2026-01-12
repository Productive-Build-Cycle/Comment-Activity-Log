namespace CommentActivityLog.Domain.Entities;

public class CommentEntity
{
    public CommentEntity()
    {
        ActivitiyLogList = new List<ActivityLogEntity>();
    }
    public int Id { get; set; }
    public string Content { get; set; }
    public bool IsDelete { get; set; }
    public int TaskId { get; set; }
    public int UserId { get; set; }
    public TaskEntity Task { get; set; }
    public UserEntity User { get; set; }
    public List<ActivityLogEntity> ActivitiyLogList { get; set; }
}