namespace User.Application.UseCases.User.Query.GetUser;

public class GetUserResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}