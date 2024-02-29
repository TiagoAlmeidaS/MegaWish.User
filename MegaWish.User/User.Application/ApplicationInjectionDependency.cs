using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Mappers.Profiles;

namespace User.Application;

public static class ApplicationInjectionDependency
{
    public static IServiceCollection ApplicationExtension(this IServiceCollection services) => services
        .AddAutoMapper()
        .AddUseCases();
    
    private static IServiceCollection AddUseCases(this IServiceCollection services) => services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });

    private static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(UserProfile));
}