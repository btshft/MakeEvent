using System;
using System.Linq;
using MakeEvent.Common.Filtering;
using MakeEvent.Domain.Models;

namespace MakeEvent.Domain.Filters
{
    public class EventFilter : SelectionParameters<Event>
    {
        public int?   CategoryId     { get; set; }
        public string OrganizationId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate   { get; set; }

        public string City { get; set; }
        public string Name { get; set; }

        public override IOrderedQueryable<Event> ApplySortingTo(IQueryable<Event> queryable)
        {
            return ApplySortingTo(queryable, e => e.StartDate);
        }
    }
}
