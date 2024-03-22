namespace Clean.Application.Common.Interfaces;
public interface IUOW
{
    Task<int> SaveAsync();
}
