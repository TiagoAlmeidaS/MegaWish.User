using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;
using User.Infra.Data.Configurations;

namespace User.Infra.Data;

public class UserDBContext: DbContext
{
    public DbSet<UserEntity> User => Set<UserEntity>();

    public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
    }
}