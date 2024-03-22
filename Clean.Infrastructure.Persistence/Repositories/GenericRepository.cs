using Clean.Domain.Common;
using Clean.Infrastructure.Persistence.Context;

namespace Clean.Infrastructure.Persistence.Repositories;
public class GenericRepository<TEntity>(ApplicationDbContext dbContext) where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _dbContext = dbContext;
    public void Add(TEntity entity) => _dbContext.Set<TEntity>().Add(entity);

    public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Attach(entity);
        _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }
    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }
}
