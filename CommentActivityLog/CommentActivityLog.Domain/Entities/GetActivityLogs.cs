using CommentActivityLog.Domain.Enums;

namespace CommentActivityLog.Domain.Entities
{
    public class GetActivityLogs
    {
        public string user_name { get; set; }
        public string task_title { get; set; }
        public string comment_content { get; set; }
        public ActionEnum activity_action { get; set; }
        public DateTime activity_action_at { get; set; }
    }
}