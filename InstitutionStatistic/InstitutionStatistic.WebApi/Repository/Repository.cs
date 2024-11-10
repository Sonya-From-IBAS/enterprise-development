using InstitutionStatistic.Domain.Models.BaseModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace InstitutionStatistic.WebApi.Repository;

public class Repository<TEntity>: IRepository<TEntity> where TEntity : class
{
    private readonly InstitutionDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public Repository(InstitutionDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public IQueryable<TEntity> Query()
    {
        return _dbSet.AsQueryable();
    }

    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByNameASync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}