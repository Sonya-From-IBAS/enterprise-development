using InstitutionStatistic.Domain.Models.BaseModel;

namespace InstitutionStatistic.Domain.Queries;

/// <summary>
/// Универсальный класс запросов сущнсотей, наследуемых от EntityWithName
/// </summary>
public abstract class GetInfoQuery<TEntity> where TEntity : EntityWithName
{
    /// <summary>
    /// Получить сущность по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TEntity? GetById(IEnumerable<TEntity> collection, Guid id) => collection.Where(x => x.Id == id).FirstOrDefault();

    /// <summary>
    /// Получить сущность по имени
    /// </summary>
    /// <param name="name"></param>
    public TEntity? GetByName(IEnumerable<TEntity> collection, string name) => collection.Where(x => x.Name == name).FirstOrDefault();
}