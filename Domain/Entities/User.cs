using Clean.Domain.Common;

namespace Clean.Domain.Entities;
public class User : BaseEntity
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }

    public ICollection<Post> Posts { get; }

}
