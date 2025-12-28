namespace CommentsAndActivityLog.Domain.Entities;

public class UserEntity
{
    public UserEntity()
    {
        CommentList = new List<CommentEntity>();
    }
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public List<CommentEntity> CommentList { get; set; }
}