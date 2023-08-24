using BookStore.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context) =>
        _context = context;

    public void Create(TEntity entity) =>
        _context.Set<TEntity>().Add(entity);

    public void Delete(TEntity entity) =>
        _context.Set<TEntity>().Remove(entity);

    public async Task<TEntity?> GetByIdAsync(int id) =>
        await _context.Set<TEntity>().FindAsync(id);

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await _context.Set<TEntity>().AsNoTracking().ToListAsync();

    public IQueryable<TEntity> GetQueryable() =>
        _context.Set<TEntity>().AsQueryable();

    public Task SaveChangesAsync() =>
        _context.SaveChangesAsync();
}