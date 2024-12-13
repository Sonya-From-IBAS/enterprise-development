using Microsoft.EntityFrameworkCore;
namespace InstitutionStatistic.WebApi.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> Query();
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> GetByNameASync(string name);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}
