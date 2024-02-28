using System.Text;
using System.Text.Json;
using Azure.Security.KeyVault.Keys.Cryptography;
using User.Shared.Common;

namespace User.Shared.Utils.Crypt;

public static class Crypt
{
    #region Encrypt
    public static string ToEncrypt<T>(this T data, CryptographyClient cryptographyClient)
    {
        try
        {
            if (data is null)
                return string.Empty;

            var valueString = JsonSerializer.Serialize(data);
            byte[] plaintext = Encoding.UTF8.GetBytes(valueString);
            EncryptResult encryptResult = cryptographyClient.Encrypt(EncryptionAlgorithm.RsaOaep, plaintext);
            return Convert.ToBase64String(encryptResult.Ciphertext);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public static string ToEncryptBase<T>(this T value, CryptographyClient cryptographyClient)
    {
        var cryptModel = new CryptModel<T>
        {
            Data = value,
            CreatedAt = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
        };

        return cryptModel.ToEncrypt(cryptographyClient);
    }

    #endregion

    #region Decrypt
    public static T? ToDecrypt<T>(this string value, CryptographyClient cryptographyClient)
    {
        byte[] byteArray = Convert.FromBase64String(value);
        DecryptResult result = cryptographyClient.Decrypt(EncryptionAlgorithm.RsaOaep, byteArray);
        return JsonSerializer.Deserialize<T>(Encoding.Default.GetString(result.Plaintext));
    }

    #endregion
}