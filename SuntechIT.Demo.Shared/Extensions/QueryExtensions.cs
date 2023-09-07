using System.Linq.Expressions;

namespace SuntechIT.Demo.Shared.Extensions;

public static class QueryExtensions
{
    public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source,
        bool shouldFilter,
        Expression<Func<TSource, bool>> predicate)
    {
        return !shouldFilter ? source : source.Where(predicate);
    }

    public static IOrderedQueryable<TSource> SortBy<TSource, TKey>(this IQueryable<TSource> source,
        Expression<Func<TSource, TKey>> keySelector,
        bool isDescending = false)
    {
        return !isDescending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
    }

    public static IOrderedQueryable<TSource> SortByX<TSource>(this IQueryable<TSource> source,
        Func<IQueryable<TSource>, IOrderedQueryable<TSource>> keySelector)
    {
        return keySelector(source);
    }
}

