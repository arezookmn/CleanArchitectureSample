using Clean.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Clean.Infrastructure.Persistence.Interceptors;
public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if(entry.State == EntityState.Deleted && entry is ISoftDeleted)
            {
                var entity = entry.Entity as ISoftDeleted;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;

            }
        }

        return result;
    }
}
