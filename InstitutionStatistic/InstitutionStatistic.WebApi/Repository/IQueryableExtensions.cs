using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.WebApi.Repository;

public static class IQueryableExtensions
{
    public static IQueryable<T> SetCondition<T>(this IQueryable<T> query, Func<T, bool> selector)
    where T : class // Предполагаем, что у вас есть интерфейс или базовый класс
    {
        return query.Where(x => selector(x));
    }
}
