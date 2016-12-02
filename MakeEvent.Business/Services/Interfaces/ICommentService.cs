using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface ICommentService
    {
        OperationResult<CommentDto> Save(CommentDto comment);
        OperationResult<CommentDto> Get(int commentId);
        OperationResult<IList<CommentDto>> All();
        OperationResult Delete(int commentId);
    }
}
