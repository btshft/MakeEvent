using System;
using System.Linq;
using System.Linq.Expressions;

namespace MakeEvent.Common.Filtering
{
    [Serializable]
    public abstract class SelectionParameters<TEntity>
    {
        public string SortingKey { get; set; }

        public SortingDirection SortingDirection { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

        public int PageSize => Take;

        public int PageNum => (Take == 0) ? 0 : Skip / Take + 1;

        public bool IsPaged => Take > 0;

        public bool IsSorted => !string.IsNullOrEmpty(SortingKey);

        public abstract IOrderedQueryable<TEntity> ApplySortingTo(IQueryable<TEntity> queryable);

        protected IOrderedQueryable<TEntity> ApplySortingTo<TKey>(IQueryable<TEntity> queryable, Expression<Func<TEntity, TKey>> keySelector)
        {
            if (keySelector == null)
                return queryable as IOrderedQueryable<TEntity>;

            return SortingDirection == SortingDirection.Ascending 
                ? queryable.OrderBy(keySelector) 
                : queryable.OrderByDescending(keySelector);
        }
    }
}
