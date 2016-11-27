using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MakeEvent.Domain.Interfaces;
using MakeEvent.Repository.Interfaces;

namespace MakeEvent.Repository.Implementations
{
    public class ReadOnlyRepository<TContext> : IReadOnlyRepository
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public ReadOnlyRepository(TContext context)
        {
            Context = context;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public virtual IQueryable<TEntity> All<TEntity>()
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>();
        }

        public virtual IQueryable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter);
        }

        public virtual TEntity Single<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter).SingleOrDefault();
        }

        public virtual TEntity First<TEntity>(
           Expression<Func<TEntity, bool>> filter = null)
           where TEntity : class, IEntity
        {
            return GetQueryable(filter).FirstOrDefault();
        }

        public virtual TEntity GetById<TEntity>(params object[] id)
            where TEntity : class, IEntity
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual int Count<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter).Count();
        }

        public virtual bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter).Any();
        }
    }
}
