namespace User.Application.UseCases.User.Command.AddUser;

public class AddUserCommandResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public AddUserCommandResult(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}