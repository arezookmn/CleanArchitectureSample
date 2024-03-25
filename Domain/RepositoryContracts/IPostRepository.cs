using Clean.Domain.Entities;

namespace Clean.Domain.RepositoryContracts;
public interface IPostRepository 
{
    void Add(Post post);
    void Delete(Post post);
    void Update(Post post);
    Task<Post> GetByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetAllPosts(int skip, int take);
}
