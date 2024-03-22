using Clean.Domain.Entities;

namespace Clean.Domain.RepositoryContracts;
public interface IUserRepository
{
    void Add(User user);
    void Delete(User user);
    void Update(User user);
    Task<User> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsers();
}
