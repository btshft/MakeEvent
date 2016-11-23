using System;
using System.Linq.Expressions;
using MakeEvent.Domain.Filters;
using MakeEvent.Domain.Models;

namespace MakeEvent.Business.Filtering.Builders
{
    public class PageFilterBuilder 
        : Common.Filtering.Builder.FilterBuilder<Page, PageFilter>
    {
        public override Expression<Func<Page, bool>> Build(PageFilter filter)
        {
            ResetPredicate();

            if (filter == null)
                return GetPredicate();

            if (string.IsNullOrEmpty(filter.PageName) == false)
                AddCondition(b => b.Name.Equals(filter.PageName, StringComparison.InvariantCultureIgnoreCase));

            if (filter.IsEditable.HasValue)
                AddCondition(b => b.IsEditable == filter.IsEditable.Value);

            return GetPredicate();
        }
    }
}
