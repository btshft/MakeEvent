using System;
using System.Linq.Expressions;
using MakeEvent.Domain.Filters;
using MakeEvent.Domain.Models;

namespace MakeEvent.Business.Filtering.Builders
{
    public class EventFilterBuilder
                : Common.Filtering.Builder.FilterBuilder<Event, EventFilter>
    {
        public override Expression<Func<Event, bool>> Build(EventFilter filter)
        {
            ResetPredicate();

            if (filter == null)
                return GetPredicate();

            if (!string.IsNullOrEmpty(filter.Name))
                AddCondition(c => c.Name.ToUpper().Contains(filter.Name.ToUpper()));

            if (!string.IsNullOrEmpty(filter.City))
                AddCondition(c => c.Name.Equals(filter.Name, StringComparison.InvariantCultureIgnoreCase));

            if (filter.CategoryId.HasValue)
                AddCondition(c => c.CategoryId == filter.CategoryId.Value);

            if (!string.IsNullOrEmpty(filter.OrganizationId))
                AddCondition(c => c.OrganizationId.Equals(filter.OrganizationId));

            if (filter.FromDate.HasValue)
                AddCondition(c => c.StartDate >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                AddCondition(c => c.EndDate <= filter.ToDate.Value);

            return GetPredicate();
        }
    }
}
