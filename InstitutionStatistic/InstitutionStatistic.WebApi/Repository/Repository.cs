using Microsoft.EntityFrameworkCore;

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

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> GetByNameASync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}