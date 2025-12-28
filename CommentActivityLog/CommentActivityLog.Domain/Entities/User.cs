namespace CommentsAndActivityLog.Domain.Entities;

public class User
{
    public User()
    {
        CommentList = new List<Comment>();
    }
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public List<Comment> CommentList { get; set; }
}