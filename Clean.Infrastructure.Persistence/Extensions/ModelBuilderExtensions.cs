using Clean.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Clean.Infrastructure.Persistence.Extensions;
public static class ModelBuilderExtensions
{
    public static void RegisterAllEntities<TBase>(this ModelBuilder modelBuilder, params Assembly[] assemblies) where TBase : class
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                                    .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && c.BaseType == typeof(TBase));

        foreach (var type in types)
        {
            modelBuilder.Entity(type);
        }

    }

    public static void ApplyQueryFilterForSoftDelete(this ModelBuilder modelBuilder, params Assembly[] assemblies) 
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                                    .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && c.GetInterfaces().Contains(typeof(ISoftDeleted)) );

        foreach (var type in types)
        {
            var entity = modelBuilder.Entity(type);
            entity.HasQueryFilter((ISoftDeleted e) => !e.IsDeleted );
        }
    }


}
