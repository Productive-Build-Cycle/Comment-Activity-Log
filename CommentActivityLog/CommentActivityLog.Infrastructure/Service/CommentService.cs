using CommentActivityLog.Application.DTOs.Comment;
using CommentActivityLog.Application.Service;
using CommentActivityLog.Infrastructure.Data;
using CommentsAndActivityLog.Domain.Entities;
using CommentsAndActivityLog.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CommentActivityLog.Infrastructure.Service;

public class CommentService : ICommentService
{
    private readonly CommentActivityLogDbContext _dbContext;
    public CommentService(CommentActivityLogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(InsertCommentDto commentDto)
    {
        var comment = new CommentEntity
        {
            Content = commentDto.Content,
            TaskId = commentDto.TaskId,
            UserId  = 1,
        };

        comment.ActivitiyLogList.Add(new ActivityLogEntity
        {
            Action  = ActionEnum.Create,
            Created_at = DateTime.Now,
        });

        await _dbContext.Comment.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(UpdateCommentDto commentDto)
    {
        var comment = await _dbContext.Comment.FirstOrDefaultAsync(comment => comment.Id == commentDto.Id);
        comment.Content = commentDto.Content;

        var activityLog = new ActivityLogEntity
        {
            Action = ActionEnum.Update,
            CommentId = comment.Id,
            Created_at = DateTime.Now,
        };

        await _dbContext.ActivityLog.AddAsync(activityLog);
        await _dbContext.SaveChangesAsync();
    }
}