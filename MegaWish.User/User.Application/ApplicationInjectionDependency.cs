using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace User.Application;

public static class ApplicationInjectionDependency
{
    public static IServiceCollection ApplicationExtension(this IServiceCollection services) => services
        .AddUseCases();
    
    private static IServiceCollection AddUseCases(this IServiceCollection services) => services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });
}