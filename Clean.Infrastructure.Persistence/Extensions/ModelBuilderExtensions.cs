using Clean.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Clean.Infrastructure.Persistence.Extensions;
public static class ModelBuilderExtensions
{
    public static void RegisterAllEntities<TBase>(this ModelBuilder modelBuilder, params Assembly[] assemblies) where TBase : class
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                                    .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic );

        foreach (var type in types)
        {
            modelBuilder.Entity(type);
        }

    }
}
