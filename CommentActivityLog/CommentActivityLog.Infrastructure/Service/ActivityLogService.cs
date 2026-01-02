using CommentActivityLog.Application.Service;
using CommentActivityLog.Infrastructure.Data;
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

    public async Task GetActivityLogs(ActivityLogDto request)
    {
        var parameters = new
        {
            fromdate = request.from_date,
            todate = request.to_date,
            user_name = request.user_name,
            action = request.action,
        };

        //FormattableString str = "";
        //var activity_logs = await _dbContext
        //    .ActivityLog
        //    .FromSql("EXEC [dbo].[sp_activity_log_report] @fromdate, @todate, @user_name, @action", parameters)
        //    .Select(x => );
    }
}
