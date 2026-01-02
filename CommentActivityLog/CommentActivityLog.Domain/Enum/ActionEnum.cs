using System.ComponentModel;

namespace CommentdActivityLog.Domain.Enums;

public enum ActionEnum
{
    [Description("ایجاد")]
    Create=1,

    [Description("حذف")]
    Delete=2,

    [Description("ویرایش")]
    Update=3,
}