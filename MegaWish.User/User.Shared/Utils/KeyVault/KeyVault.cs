using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using User.Shared.Common;

namespace User.Shared.Utils.KeyVault;

public class KeyVaultConfiguration
{
    public static CryptographyClient GetKeyClient(KeyVaultBaseConfigurations configurations)
    {
        var credentials = new ClientSecretCredential(configurations.TenantId,configurations.ClientId, configurations.ClientSecret);
        var keyClient = new KeyClient(new Uri(configurations.Url), credentials);
        var keyVaultKey = keyClient.GetKey(configurations.KeyName).Value;
            
        return new CryptographyClient(keyVaultKey.Id, credentials);
    }
}