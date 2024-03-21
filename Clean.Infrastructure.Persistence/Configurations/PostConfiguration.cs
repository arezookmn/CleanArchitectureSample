using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Persistence.Configurations;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.text)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.title)
            .HasMaxLength(300)
            .IsRequired();
    }
}
