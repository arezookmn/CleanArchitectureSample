namespace Clean.Application.Common.Interfaces;
public interface IApplicationUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken);
}
