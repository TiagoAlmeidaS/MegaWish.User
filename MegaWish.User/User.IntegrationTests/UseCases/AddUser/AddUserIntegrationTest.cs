using AutoMapper;
using Moq;
using User.Application.UseCases.User.Command.AddUser;
using User.Domain.Entities;
using User.Infra.Data;
using User.Infra.Data.Repositories;
using User.IntegrationTests.Configuration;
using Xunit;

namespace User.IntegrationTests.UseCases.AddUser;

public class AddUserIntegrationTests : IntegrationTestBase
{
    [Fact]
    public async Task AddUser_ShouldPersistInDatabase()
    {
        var dbContext = CreateDbContextInMemory();
        var userRepository = new UserRepository(dbContext);
        var unitOfWork = new UnitOfWork(dbContext);
        
        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<UserEntity>(It.IsAny<AddUserCommand>()))
            .Returns((AddUserCommand src) => new UserEntity(src.Name, src.Email, src.YearsOld, src.CustomerDocument, src.PhoneNumber));

        var handler = new AddUserCommandHandler(userRepository, unitOfWork, mockMapper.Object);
        
        var command = new AddUserCommand(Faker.NameFaker.FirstName(), Faker.InternetFaker.Email(), Faker.NumberFaker.Number(), Faker.StringFaker.Numeric(11), Faker.PhoneFaker.Phone());
        var result = await handler.Handle(command, CancellationToken.None);
        
        var userInDb = await dbContext.User.FindAsync(result.Id);
        Assert.NotNull(userInDb);
        Assert.Equal(command.Name, userInDb.Name);
        Assert.Equal(command.Email, userInDb.Email);
    }
}