using CommentActivityLog.Application.DTOs.ActivityLog;
using CommentActivityLog.Domain.Entities;

namespace CommentActivityLog.Application.Service;

public interface IActivityLogService
{
    Task<List<GetActivityLogs>> GetActivityLogs(ActivityLogDto request);
}