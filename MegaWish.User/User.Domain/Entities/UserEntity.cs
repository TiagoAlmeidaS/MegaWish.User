using User.Domain.SeedWork;

namespace User.Domain.Entities;

public class UserEntity: AggregateRoot
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int YearOld { get; set; }
    public string CustomerDocument { get; set; }
    public string PhoneNumber { get; set; }

    public UserEntity(string name, string email, int yearOld, string customerDocument, string phoneNumber)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        YearOld = yearOld;
        CustomerDocument = customerDocument;
        PhoneNumber = phoneNumber;
        CreatedAt = DateTime.UtcNow;
        Validate();
    }
    
    public void Update(string name, string email, int yearOld, string customerDocument, string phoneNumber)
    {
        Name = name;
        Email = email;
        YearOld = yearOld;
        CustomerDocument = customerDocument;
        PhoneNumber = phoneNumber;
        
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Delete()
    {
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Validate()
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentException("Name is required");
        
        if (string.IsNullOrEmpty(Email))
            throw new ArgumentException("Email is required");
        
        if (YearOld <= 0)
            throw new ArgumentException("YearOld is required");
        
        if (string.IsNullOrEmpty(CustomerDocument))
            throw new ArgumentException("CustomerDocument is required");
        
        if (PhoneNumber.Length <= 0)
            throw new ArgumentException("PhoneNumber is required");
    }
}