using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Interfaces;
using User.Domain.Repositories;
using User.Infra.Data.Repositories;

namespace User.Infra.Data;

public static class InfraDataDependencyInjection
{
    public static IServiceCollection
        InfraDataExtensions(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddDbConnection(configuration)
            .AddRepositories();

    private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var useInMemoryDatabase = configuration.GetValue<bool>("UserDB:UseInMemoryDatabase");

        if (useInMemoryDatabase)
        {
            services.AddDbContextPool<UserDBContext>(options =>
                options.UseInMemoryDatabase("TestingDB"));
        }
        else
        {
            services.AddDbContextPool<UserDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("DB")));
        }

        return services;
    }
        
    
    private static IServiceCollection AddRepositories(this IServiceCollection services) => services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IUnitOfWork, UnitOfWork>();
    
    
    
}