namespace InstitutionStatistic.Domain.Queries;

public interface IGetInfoQuery<TEntity> where TEntity : class
{
    /// <summary>
    /// Получить сущность по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TEntity? GetById(IEnumerable<TEntity> collection, Guid id);

    /// <summary>
    /// Получить сущность по имени
    /// </summary>
    /// <param name="name"></param>
    public TEntity? GetByName(IEnumerable<TEntity> collection, string name);
}
