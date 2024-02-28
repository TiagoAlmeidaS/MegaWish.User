using AutoMapper;
using Moq;
using User.Application.Interfaces;
using User.Application.UseCases.User.Command.AddUser;
using User.Domain.Entities;
using User.Domain.Repositories;
using Xunit;

namespace User.UnitTests.Application.UseCases;

public class AddUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _mockRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IMapper> _mockMapper = new();

    [Fact]
    public async void Handle_ShouldAddUserSuccessfully()
    {
        var fakerName = Faker.NameFaker.FirstName();
        var fakerEmail = Faker.InternetFaker.Email();
        var fakerAge = Faker.NumberFaker.Number();
        var fakerCustomerDocument = Faker.StringFaker.Numeric(11);
        var fakerPhone = Faker.PhoneFaker.Phone();
        
        var handler = new AddUserCommandHandler(_mockRepository.Object, _mockUnitOfWork.Object, _mockMapper.Object);
        var command = new AddUserCommand(fakerName, fakerEmail, fakerAge, fakerCustomerDocument, fakerPhone);

        _mockMapper.Setup(m => m.Map<UserEntity>(It.IsAny<AddUserCommand>()))
            .Returns(new UserEntity(fakerName, fakerEmail, fakerAge, fakerCustomerDocument, fakerPhone));

        var result = await handler.Handle(command, new CancellationToken());

        _mockRepository.Verify(r => r.Insert(It.IsAny<UserEntity>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.Commit(It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(result);
        Assert.Equal(fakerName, result.Name);
        Assert.Equal(fakerEmail, result.Email);
    }
}