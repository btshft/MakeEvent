using System.Linq;
using AutoMapper.QueryableExtensions;
using MakeEvent.Common.Filtering;
using MakeEvent.Common.Models;

namespace MakeEvent.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static PaginatedResult<TResult> ToPaginatedResult<TSource, TResult>(
            this IOrderedQueryable<TSource> sourceCollection,
            SelectionParameters<TSource> selectionParameters)
        {
            var paginatedCollection = new PaginatedResult<TResult>();

            if (sourceCollection == null)
                return paginatedCollection;

            IQueryable<TSource> resultCollection = sourceCollection;
            paginatedCollection.TotalRows = resultCollection.Count();

            if (selectionParameters?.IsPaged == true)
            {
                resultCollection = sourceCollection.ApplyPaging(selectionParameters);
            }

            paginatedCollection.Items = resultCollection.ProjectTo<TResult>().ToList();

            return paginatedCollection;
        }

        public static IOrderedQueryable<TValue> ApplySorting<TValue>(this IQueryable<TValue> sourceCollection,
            SelectionParameters<TValue> selectionParameters)
        {
            IOrderedQueryable<TValue> resultCollection = null;

            if (sourceCollection != null && selectionParameters != null)
            {
                resultCollection = selectionParameters.ApplySortingTo(sourceCollection);
            }

            return resultCollection;
        }

        public static IQueryable<TValue> ApplyPaging<TValue>(this IOrderedQueryable<TValue> sourceCollection,
            SelectionParameters<TValue> selectionParameters)
        {
            IQueryable<TValue> resultCollection = sourceCollection;

            if (sourceCollection == null || selectionParameters?.IsPaged != true)
                return resultCollection;

            if (selectionParameters.Skip > 0)
                resultCollection = resultCollection.Skip(selectionParameters.Skip);
            if (selectionParameters.Take > 0)
                resultCollection = resultCollection.Take(selectionParameters.Take);

            return resultCollection;
        }
    }
}
