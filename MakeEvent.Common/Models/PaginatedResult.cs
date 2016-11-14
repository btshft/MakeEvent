using System.Collections;
using System.Collections.Generic;

namespace MakeEvent.Common.Models
{
    public class PaginatedResult<T> : IEnumerable<T>
    {
        public PaginatedResult()
        { }

        public PaginatedResult(IEnumerable<T> items, int totalRows)
        {
            Items = items;
            TotalRows = totalRows;
        }

        public IEnumerable<T> Items { get; set; }

        public int TotalRows { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
