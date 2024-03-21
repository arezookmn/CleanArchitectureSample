using Clean.Domain.Common;

namespace Clean.Domain.Entities;
public class Post : BaseEntity
{
    public string text { get; init; }
    public string title { get; init; }
    public ICollection<User> Users { get; }

}
