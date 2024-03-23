using Clean.Application.Common.Interfaces;
using Clean.Infrastructure.Persistence.Context;

namespace Clean.Infrastructure.Persistence.UnitOfWork;
public class ApplicationUnitOfWork (ApplicationDbContext dbContext): IApplicationUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;   
    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
