using System;
using System.Linq.Expressions;
using LinqKit;

namespace MakeEvent.Common.Filtering.Builder
{
    public abstract class FilterBuilder<TEntity, TFilterObject> 
        : IFilterBuilder<TEntity, TFilterObject> where TEntity : class
    {
        private Expression<Func<TEntity, bool>> _predicateLambdaExpression;

        public abstract Expression<Func<TEntity, bool>> Build(TFilterObject filter);

        protected Expression<Func<TEntity, bool>> GetPredicate()
        {
            return _predicateLambdaExpression != null 
                ? _predicateLambdaExpression.Expand() 
                :  PredicateBuilder.True<TEntity>();
        }

        protected void ResetPredicate()
        {
            _predicateLambdaExpression = null;
        }

        protected void AddCondition(Expression<Func<TEntity, bool>> additionalPredicate)
        {
            if (_predicateLambdaExpression == null)
            {
                _predicateLambdaExpression = additionalPredicate;
            }
            else
            {
                _predicateLambdaExpression = _predicateLambdaExpression.And(additionalPredicate);
            }
        }
    }
}
