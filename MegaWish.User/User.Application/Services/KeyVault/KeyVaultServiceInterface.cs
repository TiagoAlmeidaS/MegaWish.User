using User.Shared.Common;

namespace User.Application.Services.KeyVault;

public interface IKeyVaultService
{
    public CryptModel<string>? DecryptDocumentNumber(KeyVaultBaseConfigurations configurations, string encryptedDocumentNumber);
}