using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace User.Presentation.Extensions;

public static class PresentationExtensions
{
    public static void ConfigureKeyVault(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        var keyVaultClientId = configuration["KeyVaultConfiguration:ClientId"];
        var keyVaultTenantId = configuration["KeyVaultConfiguration:TenantId"];
        var keyVaultClientSecret = configuration["KeyVaultConfiguration:ClientSecret"];
        var keyVaultUrl = configuration["KeyVaultConfiguration:Url"];
        var hasReloadInterval = int.TryParse(configuration["BaseConfigurations:ReloadInterval"],
            out var reloadInterval);

        var secretClient = new SecretClient(new Uri(keyVaultUrl),
            new ClientSecretCredential(keyVaultTenantId, keyVaultClientId, keyVaultClientSecret));

        builder.Configuration.AddAzureKeyVault(
            secretClient,
            new AzureKeyVaultConfigurationOptions()
            {
                Manager = new KeyVaultSecretManager(),
                ReloadInterval = TimeSpan.FromSeconds(hasReloadInterval ? reloadInterval : 30),
            });
    }
}