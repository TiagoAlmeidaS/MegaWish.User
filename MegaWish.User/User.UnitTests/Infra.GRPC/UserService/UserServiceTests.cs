using AutoMapper;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using User.Application.UseCases.User.Query.GetUser;
using User.Infra.GRPC;
using Xunit;

namespace User.UnitTests.Infra.GRPC.UserService;

public class UserServiceTests
{
    private readonly Mock<ILogger<User.Infra.GRPC.Services.UserService>> _mockLogger;
    private readonly Mock<ISender> _mockMediator;
    private readonly Mock<IMapper> _mockMapper;
    private readonly User.Infra.GRPC.Services.UserService _userService;
    private readonly Mock<ServerCallContext> _context;

    public UserServiceTests()
    {
        _mockLogger = new Mock<ILogger<User.Infra.GRPC.Services.UserService>>();
        _mockMediator = new Mock<ISender>();
        _mockMapper = new Mock<IMapper>();
        _userService = new User.Infra.GRPC.Services.UserService(_mockLogger.Object, _mockMediator.Object, _mockMapper.Object);
        _context = new Mock<ServerCallContext>();
    }

    [Fact]
    public async Task GetUser_ReturnsExpectedUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var fakerCustomerDocument = Faker.StringFaker.Numeric(11);
        var fakerName = Faker.NameFaker.Name();
        var fakerEmail = Faker.InternetFaker.Email();
        
        var getUserRequest = new GetUserRequest { Id = userId.ToString(), CustomerDocument = fakerCustomerDocument };
        var getUserQuery = new GetUserQuery { Id = userId, CustomerDocument = fakerCustomerDocument };
        var getUserResult = new GetUserResult()
        {
            Email = fakerEmail,
            Id = userId,
            Name = fakerName,
        };

        _mockMediator.Setup(m => m.Send(It.IsAny<GetUserQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(getUserResult);

        // Act
        var response = await _userService.GetUser(getUserRequest, _context.Object);

        // Assert
        Assert.Equal(userId.ToString(), response.Id);

        // Verifica se o MediatR foi chamado com o Query correto
        _mockMediator.Verify(m => m.Send(It.Is<GetUserQuery>(q => q.Id == userId && q.CustomerDocument == fakerCustomerDocument), It.IsAny<CancellationToken>()), Times.Once);
    }
}