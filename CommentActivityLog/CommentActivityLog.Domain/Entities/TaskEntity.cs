namespace CommentsAndActivityLog.Domain.Entities;

public class TaskEntity
{
    public TaskEntity()
    {
        CommentList = new List<CommentEntity>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<CommentEntity> CommentList { get; set; }
}