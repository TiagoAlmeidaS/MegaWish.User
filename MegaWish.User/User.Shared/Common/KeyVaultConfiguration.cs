namespace User.Shared.Common;

public abstract class KeyVaultBaseConfigurations
{
    public string Url { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string TenantId { get; set; }
    public string KeyName { get; set; }
}