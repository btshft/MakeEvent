using System;
using System.Linq.Expressions;

namespace MakeEvent.Common.Filtering.Builder
{
    public interface IFilterBuilder<TEntity, in TFilterObject>
    {
        Expression<Func<TEntity, bool>> Build(TFilterObject filter);
    }
}
