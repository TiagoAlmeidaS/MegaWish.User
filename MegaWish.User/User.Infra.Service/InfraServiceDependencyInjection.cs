using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Services.KeyVault;
using User.Infra.Service.KeyVault;

namespace User.Infra.Service;

public static class InfraServiceDependencyInjection
{
    public static IServiceCollection InfraServiceExtensions(this IServiceCollection services, IConfiguration configuration) =>
        services.AddServices();
    
    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddSingleton<IKeyVaultService, KeyVaultService>();
}