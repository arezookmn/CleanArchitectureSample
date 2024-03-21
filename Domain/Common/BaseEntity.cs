namespace Clean.Domain.Common;
public class BaseEntity
{
    public Guid Id { get; init; }
    public bool IsDeleted { get; init; }
}
