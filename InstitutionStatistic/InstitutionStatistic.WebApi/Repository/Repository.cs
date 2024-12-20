﻿using Microsoft.EntityFrameworkCore;

namespace InstitutionStatistic.WebApi.Repository;

public class Repository<TEntity>(InstitutionDbContext context) : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    public IQueryable<TEntity> Query()
    {
        return _dbSet.AsQueryable();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetByNameASync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await context.SaveChangesAsync();
    }
}