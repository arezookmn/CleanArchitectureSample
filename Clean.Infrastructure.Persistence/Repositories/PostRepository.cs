using Clean.Domain.Entities;
using Clean.Domain.RepositoryContracts;
using Clean.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Persistence.Repositories;
public class PostRepository(ApplicationDbContext dbContext) : GenericRepository<Post>(dbContext), IPostRepository
{
    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        return await _dbContext.Set<Post>().ToListAsync();
    }

}
