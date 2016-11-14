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
            where TEntity : class, IEntity;

        IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        TEntity First<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        TEntity GetById<TEntity>(object id)
            where TEntity : class, IEntity;

        int Count<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;
    }
}
