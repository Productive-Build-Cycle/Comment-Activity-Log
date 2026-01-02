using CommentActivityLog.Application.DTOs.Comment;
using CommentActivityLog.Application.Service;
using CommentActivityLog.Infrastructure.Data;
using CommentActivityLog.Domain.Entities;
using CommentActivityLog.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CommentActivityLog.Infrastructure.Service;

public class CommentService : ICommentService
{
    private readonly CommentActivityLogDbContext _dbContext;
    public CommentService(CommentActivityLogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(InsertCommentDto commentDto)
    {
        var created_date = DateTime.Now;
        var comment = new CommentEntity
        {
            Content = commentDto.Content,
            TaskId = commentDto.TaskId,
            UserId  = 1,
        };

        comment.ActivitiyLogList.Add(new ActivityLogEntity
        {
            Action  = ActionEnum.Create,
            Created_at = created_date,
        });

        await _dbContext.Comment.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(UpdateCommentDto commentDto)
    {
        var comment = await _dbContext.Comment.FindAsync(commentDto.Id);
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
    public async Task DeleteAsync(int id)
    {
        var comment = await _dbContext.Comment.FindAsync(id);
        comment.IsDelete = true;

        var activityLog = new ActivityLogEntity
        {
            Action = ActionEnum.Delete,
            CommentId = comment.Id,
            Created_at = DateTime.Now,
        };

        await _dbContext.ActivityLog.AddAsync(activityLog);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<CommentDto> GetByIdAsync(int id)
    {
        var comment = await _dbContext.Comment.FindAsync(id);
        var response = new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            IsDelete = comment.IsDelete,
            TaskId = comment.TaskId
        };

        return response;
    }
    public async Task<List<CommentDto>> GetAllByTaskIdAsync(int taskId)
    {
        var comments = await _dbContext.Comment.Select(comment => new  CommentDto
        {
            Content = comment.Content,
            Id  = comment.Id,
            TaskId = comment.TaskId,
            IsDelete = comment.IsDelete
        })
        .OrderByDescending(comment => comment.Id)
        .ToListAsync();

        return comments;
    }
}