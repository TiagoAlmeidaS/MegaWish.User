using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;
using User.Infra.Data;
using User.Infra.Data.Repositories;
using Xunit;

namespace User.UnitTests.Infra.Data.Repositories;

public class UserRepositoryTests
{
    private readonly UserDBContext _context;
    private readonly UserRepository _repository;

    public UserRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<UserDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        
        _context = new UserDBContext(options);
        _repository = new UserRepository(_context);
    }

    [Fact]
    public async Task Insert_ShouldAddUserCorrectly()
    {
        var cancellationToken = new CancellationToken();
        var user = new UserEntity(Faker.NameFaker.FirstName(), Faker.InternetFaker.Email(), Faker.NumberFaker.Number(),Faker.StringFaker.Numeric(11).ToString(), Faker.PhoneFaker.Phone());
        await _repository.Insert(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var userInDb = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email);
        
        Assert.NotNull(userInDb);
        Assert.Equal(userInDb?.Name, user.Name);
    }

    [Fact]
    public async Task GetWhere_ShouldReturnCorrectUsers()
    {
        var fakerName = Faker.NameFaker.FirstName();
        
        _context.User.Add(new UserEntity(fakerName, Faker.InternetFaker.Email(), Faker.NumberFaker.Number(),Faker.StringFaker.Numeric(11).ToString(), Faker.PhoneFaker.Phone()));
        _context.User.Add(new UserEntity(fakerName, Faker.InternetFaker.Email(), Faker.NumberFaker.Number(),Faker.StringFaker.Numeric(11).ToString(), Faker.PhoneFaker.Phone()));
        
        await _context.SaveChangesAsync();

        var users = await _repository.GetWhere(u => u.Name.Contains(fakerName), new CancellationToken());
        Assert.Equal(2, users.Count);
    }
}