using Clean.Application.Common.Interfaces;
using Clean.Infrastructure.Persistence.Context;

namespace Clean.Infrastructure.Persistence.UnitOfWork;
public class UOW (ApplicationDbContext dbContext): IUOW
{
    private readonly ApplicationDbContext _dbContext = dbContext;   
    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
