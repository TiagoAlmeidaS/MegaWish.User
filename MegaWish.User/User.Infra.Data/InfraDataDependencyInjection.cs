using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Interfaces;
using User.Domain.Repositories;

namespace User.Infra.Data;

public static class InfraDataDependencyInjection
{
    public static IServiceCollection
        InfraDataExtensions(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddDbConnection(configuration)
            .AddRepositories();

    private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContextPool<UserDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("DB")));
    
    private static IServiceCollection AddRepositories(this IServiceCollection services) => services
        .AddScoped<IUserRepository, IUserRepository>()
        .AddScoped<IUnitOfWork, UnitOfWork>();
    
    
    
}