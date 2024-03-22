namespace Clean.Domain.Common;
public interface ISoftDeleted
{
    public bool IsDeleted { get; set; }
}
