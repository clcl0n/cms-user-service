using Cms.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Cms.UserService.Infrastructure.Persistence.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(x => x.Id).HasName("PK_user___id");

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasValueGenerator((_, _) => new GuidValueGenerator());
        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);

        builder.HasIndex(x => x.ImageId).HasDatabaseName("IX_user___image_id");
    }
}
