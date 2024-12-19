using InstitutionStatistic.Domain.Models.BaseModel;

namespace InstitutionStatistic.Domain.Queries;

/// <summary>
/// Универсальный класс запросов сущнсотей, наследуемых от EntityWithName
/// </summary>
public abstract class GetInfoQuery<TEntity>: IGetInfoQuery<TEntity> where TEntity : EntityWithName
{
    public TEntity? GetById(IEnumerable<TEntity> collection, Guid id) => collection.Where(x => x.Id == id).FirstOrDefault();

    public TEntity? GetByName(IEnumerable<TEntity> collection, string name) => collection.Where(x => x.Name == name).FirstOrDefault();
}