using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;

namespace MakeEvent.Business.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IRepository _repository;

        public CommentService(IRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<CommentDto> Save(CommentDto comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            var existed = _repository.GetById<Comment>(comment.Id);
            var result = (existed != null)
                ? UpdateComment(existed, comment)
                : CreateComment(comment);

            return result;
        }

        public OperationResult<CommentDto> Get(int commentId)
        {
            var comment = _repository.GetById<Comment>(commentId);

            return comment == null
                ? OperationResult.Fail<CommentDto>("Не удалось найти комментарий")
                : OperationResult.Success(Mapper.Map<CommentDto>(comment));
        }

        public OperationResult<IList<CommentDto>> GetByOrganization(string organizationId)
        {
            var comments = _repository.Get<Comment>(c => c.OrganizationId.Equals(organizationId))
                .ProjectTo<CommentDto>()
                .ToList();

            return OperationResult.Success<IList<CommentDto>>(comments);
        }

        public OperationResult<IList<CommentDto>> All()
        {
            var comments = _repository.Get<Comment>()
                .ProjectTo<CommentDto>()
                .ToList();

            return OperationResult.Success<IList<CommentDto>>(comments);
        }

        public OperationResult Delete(int commentId)
        {
            var exists = _repository.GetById<Comment>(commentId);
            if (exists == null)
                return OperationResult.Fail($"Комментарий с id = {commentId} не найден.");

            _repository.Delete<Comment>(commentId);
            _repository.Save();

            return OperationResult.Success();
        }

        private OperationResult<CommentDto> CreateComment(CommentDto comment)
        {
            var domain = Mapper.Map<Comment>(comment);
            var result = _repository.Create(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<CommentDto>(result));
        }

        private OperationResult<CommentDto> UpdateComment(Comment domain, CommentDto comment)
        {
            domain = Mapper.Map(comment, domain);
            var result = _repository.Update(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<CommentDto>(result));
        }
    }
}
