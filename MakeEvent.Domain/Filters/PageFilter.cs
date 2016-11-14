using System.Linq;
using MakeEvent.Common.Filtering;
using MakeEvent.Domain.Models;

namespace MakeEvent.Domain.Filters
{
    public class PageFilter : SelectionParameters<Page>
    {
        public bool? IsEditable { get; set; }
        public string PageName { get; set; }

        public override IOrderedQueryable<Page> ApplySortingTo(IQueryable<Page> queryable)
        {
            return ApplySortingTo(queryable, p => p.PageName);
        }
    }
}
