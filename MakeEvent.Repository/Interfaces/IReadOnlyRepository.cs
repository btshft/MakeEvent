using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MakeEvent.Domain.Interfaces;

namespace MakeEvent.Repository.Interfaces
{
    public interface IReadOnlyRepository
    {
        IEnumerable<TEntity> All<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
                where TEntity : class, IEntity;

        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
                where TEntity : class, IEntity;

        TEntity Single<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
                where TEntity : class, IEntity;

        TEntity First<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
                where TEntity : class, IEntity;

        TEntity GetById<TEntity>(object id)
            where TEntity : class, IEntity;

        int Count<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;
    }
}
