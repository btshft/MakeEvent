using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MakeEvent.Domain.Interfaces;

namespace MakeEvent.Repository.Interfaces
{
    public interface IReadOnlyRepository
    {
        IQueryable<TEntity> All<TEntity>()
            where TEntity : class;

        IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        TEntity First<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        TEntity GetById<TEntity>(params object[] id)
            where TEntity : class;

        int Count<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;
    }
}
