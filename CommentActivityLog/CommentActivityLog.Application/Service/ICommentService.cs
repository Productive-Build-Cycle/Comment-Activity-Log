using CommentActivityLog.Application.DTOs.Comment;
using System.Net.NetworkInformation;

namespace CommentActivityLog.Application.Service;

public interface ICommentService
{
    Task Create(InsertCommentDto commentDto);
    Task Update(UpdateCommentDto commentDto);
    // insert service
    // update comment
    // delete comment 
    // getall
    // get by id
}