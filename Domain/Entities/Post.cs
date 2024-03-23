using Clean.Domain.Common;
using System.Reflection.Metadata;

namespace Clean.Domain.Entities;
public class Post : BaseEntity, ISoftDeleted
{
    public string text { get; init; }
    public string title { get; init; }
    public Guid UserId { get; init; } 
    public User user { get; init; } = null!; 
    public bool IsDeleted { get ; set ; }
}
