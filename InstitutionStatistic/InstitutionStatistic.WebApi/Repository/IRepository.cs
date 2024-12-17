using Microsoft.EntityFrameworkCore;
namespace InstitutionStatistic.WebApi.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> Query();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> GetByNameASync(string name);
    Task<List<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}
