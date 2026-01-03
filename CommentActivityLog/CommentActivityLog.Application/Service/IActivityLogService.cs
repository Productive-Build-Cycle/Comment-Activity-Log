using CommentActivityLog.Application.DTOs.ActivityLog;
using CommentActivityLog.Domain.Common;
using CommentActivityLog.Domain.Entities;

namespace CommentActivityLog.Application.Service;

public interface IActivityLogService
{
    Task<Result<List<GetActivityLogs>>> GetActivityLogs(ActivityLogDto request);
}