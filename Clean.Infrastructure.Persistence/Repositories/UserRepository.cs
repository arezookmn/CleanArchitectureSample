using Clean.Domain.Entities;
using Clean.Domain.RepositoryContracts;
using Clean.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Persistence.Repositories;
public class UserRepository(ApplicationDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
{
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _dbContext.Set<User>().ToListAsync(); 
    }
}
