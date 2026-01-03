using CommentActivityLog.Application.DTOs.ActivityLog;
using CommentActivityLog.Application.Service;
using CommentActivityLog.Domain.Entities;
using CommentActivityLog.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace CommentActivityLog.Infrastructure.Service;

public class ActivityLogService : IActivityLogService
{
    private readonly CommentActivityLogDbContext _dbContext;

    public ActivityLogService(CommentActivityLogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetActivityLogs>> GetActivityLogs(ActivityLogDto request)
    {
        var parameters = new[]
        {
            new SqlParameter("@fromdate" , request.from_date.HasValue ? request.from_date: DBNull.Value),
            new SqlParameter("@todate" , request.to_date.HasValue ? request.to_date: DBNull.Value),
            new SqlParameter("@user_name" , string.IsNullOrEmpty(request.user_name) ? DBNull.Value : request.user_name),
            new SqlParameter("@action" , request.action is null ? DBNull.Value : request.action),
        };

        var activity_logs = await _dbContext
            .GetActivityLogs
            .FromSqlRaw("EXEC [dbo].[sp_activity_log_report] @fromdate, @todate, @user_name, @action", parameters)
            .AsNoTracking()
            .ToListAsync();

        return activity_logs;

    }
}
