using CommentActivityLog.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CommentActivityLog.Api.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class ActivityLogController : ControllerBase
{
    private readonly IActivityLogService _activityLogService;
    public ActivityLogController(IActivityLogService activityLogService)
    {
        _activityLogService = activityLogService;
    }

    [HttpGet()]
    public async Task<IActionResult> GetCommentActivityLogs([FromQuery] ActivityLogDto request)
    {
        await _activityLogService.GetActivityLogs(request);
        return Ok();
    }
}