namespace User.Shared.Common;

public class CryptModel<T>
{
    public T Data { get; set; }
    public long CreatedAt { get; set; }
}