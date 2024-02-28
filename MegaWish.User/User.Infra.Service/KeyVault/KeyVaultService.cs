using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.Extensions.Options;
using User.Application.Services.KeyVault;
using User.Shared.Common;
using User.Shared.Utils.Crypt;
using User.Shared.Utils.KeyVault;

namespace User.Infra.Service.KeyVault;

public class KeyVaultService: IKeyVaultService
{
    private readonly CryptographyClient _cryptographyClient;
    public KeyVaultService(IOptions<KeyVaultBaseConfigurations> configurations)
    {
        _cryptographyClient = KeyVaultConfiguration.GetKeyClient(configurations.Value);
    }

    public CryptModel<string>? DecryptDocumentNumber(KeyVaultBaseConfigurations configurations, string encryptedDocumentNumber)
    {
        try
        {
            return encryptedDocumentNumber.ToDecrypt<CryptModel<string>>(_cryptographyClient);
        }
        catch (Exception)
        {
            return new CryptModel<string>();
        }
    }
}