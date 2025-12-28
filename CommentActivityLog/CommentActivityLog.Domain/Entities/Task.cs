namespace CommentsAndActivityLog.Domain.Entities;

public class Task
{
    public Task()
    {
        CommentList = new List<Comment>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Comment> CommentList { get; set; }
}