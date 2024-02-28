using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Entities;

namespace User.Infra.Data.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(cm => cm.Id);
        builder.Property(cm => cm.Name).IsRequired();
        builder.Property(cm => cm.Email).IsRequired();
        builder.Property(medals => medals.UpdatedAt).HasDefaultValueSql("now()");
        builder.Property(medals => medals.CreatedAt).HasDefaultValueSql("now()");
    }
}