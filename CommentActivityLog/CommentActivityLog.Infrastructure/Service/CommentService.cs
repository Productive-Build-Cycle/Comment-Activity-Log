using CommentActivityLog.Application.DTOs.Comment;
using CommentActivityLog.Application.Service;
using CommentActivityLog.Domain.Common;
using CommentActivityLog.Domain.Entities;
using CommentActivityLog.Domain.Enums;
using CommentActivityLog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CommentActivityLog.Infrastructure.Service;

public class CommentService : ICommentService
{
    private readonly CommentActivityLogDbContext _dbContext;
    public CommentService(CommentActivityLogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> CreateAsync(InsertCommentDto commentDto)
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

        return new Result
        {
            IsSuccess = true,
            Message = "comment created successfully."
        };
    }
    public async Task<Result> UpdateAsync(UpdateCommentDto commentDto)
    {
        var comment = await _dbContext.Comment.FindAsync(commentDto.Id);
        if(comment is null)
        {
            return new Result
            {
                IsSuccess = false,
                Message = "comment not found."
            };
        }

        comment.Content = commentDto.Content;

        var activityLog = new ActivityLogEntity
        {
            Action = ActionEnum.Update,
            CommentId = comment.Id,
            Created_at = DateTime.Now,
        };

        await _dbContext.ActivityLog.AddAsync(activityLog);
        await _dbContext.SaveChangesAsync();

        return new Result
        {
            IsSuccess = true,
            Message = "comment updated successfully."
        };
    }
    public async Task<Result> DeleteAsync(int id)
    {
        var comment = await _dbContext.Comment.FindAsync(id);

        if (comment is null)
        {
            return new Result
            {
                IsSuccess = false,
                Message = "comment not found."
            };
        }

        comment.IsDelete = true;

        var activityLog = new ActivityLogEntity
        {
            Action = ActionEnum.Delete,
            CommentId = comment.Id,
            Created_at = DateTime.Now,
        };

        await _dbContext.ActivityLog.AddAsync(activityLog);
        await _dbContext.SaveChangesAsync();

        return new Result
        {
            IsSuccess = true,
            Message = "comment deleted successfully."
        };
    }
    public async Task<Result<CommentDto>> GetByIdAsync(int id)
    {
        var comment = await _dbContext.Comment.FindAsync(id);
        if (comment is null)
        {
            return new Result<CommentDto>
            {
                IsSuccess = false,
                Message = "comment not found."
            };
        }

        var response = new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            IsDelete = comment.IsDelete,
            TaskId = comment.TaskId
        };

        return new Result<CommentDto>
        {
            IsSuccess = true,
            Data = response
        };
    }
    public async Task<Result<List<CommentDto>>> GetAllByTaskIdAsync(int taskId)
    {
        var comments = await _dbContext.Comment.Select(comment => new  CommentDto
        {
            Content = comment.Content,
            Id  = comment.Id,
            TaskId = comment.TaskId,
            IsDelete = comment.IsDelete
        })
        .AsNoTracking()
        .OrderByDescending(comment => comment.Id)
        .ToListAsync();

        return new Result<List<CommentDto>>
        {
            IsSuccess = true,
            Data = comments
        };
    }
}