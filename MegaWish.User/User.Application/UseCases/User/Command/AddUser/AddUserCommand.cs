using MediatR;

namespace User.Application.UseCases.User.Command.AddUser;

public class AddUserCommand: IRequest<AddUserCommandResult>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int YearsOld { get; set; }
    public string CustomerDocument { get; set; }
    public int PhoneNumber { get; set; }
    
    public AddUserCommand(string name, string email, int yearsOld, string customerDocument, int phoneNumber)
    {
        Name = name;
        Email = email;
        YearsOld = yearsOld;
        CustomerDocument = customerDocument;
        PhoneNumber = phoneNumber;
        
        Validate();
    }
    
    public void Validate()
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentException("Name is required");
        
        if (string.IsNullOrEmpty(Email))
            throw new ArgumentException("Email is required");
        
        if (YearsOld <= 0)
            throw new ArgumentException("YearsOld is required");
        
        if (string.IsNullOrEmpty(CustomerDocument))
            throw new ArgumentException("CustomerDocument is required");
        
        if (PhoneNumber <= 0)
            throw new ArgumentException("PhoneNumber is required");
    }
}