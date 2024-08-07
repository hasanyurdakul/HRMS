using HRMS.CORE;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRMS.DAL;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(AppDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _entities.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _entities.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        _entities.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
        _context.SaveChanges();
    }
}
