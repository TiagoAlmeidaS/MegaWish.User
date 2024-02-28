namespace User.Application.Services.Dto;

public class AddUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string CustomerDocument { get; set; }
    public int PhoneNumber { get; set; }
}