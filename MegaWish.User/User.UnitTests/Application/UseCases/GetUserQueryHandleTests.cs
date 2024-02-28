using System.Linq.Expressions;
using AutoMapper;
using Moq;
using User.Application.Interfaces;
using User.Application.UseCases.User.Command.AddUser;
using User.Application.UseCases.User.Query.GetUser;
using User.Domain.Entities;
using User.Domain.Repositories;
using Xunit;

namespace User.UnitTests.Application.UseCases;

public class GetUserQueryHandleTests
{
    private readonly Mock<IUserRepository> _mockRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IMapper> _mockMapper = new();
    
    [Fact]
    public async void Handle_ShoulGetUserSuccessfully()
    {
        var fakerName = Faker.NameFaker.FirstName();
        var fakerEmail = Faker.InternetFaker.Email();
        var fakerCustomerDocument = Faker.StringFaker.Numeric(11);
        var fakerPhone = Faker.PhoneFaker.Phone();
        
        var query = new GetUserQuery()
        {
            CustomerDocument = fakerCustomerDocument
        };
        
        _mockRepository.Setup(repo => repo.Get(query.Id, query.CustomerDocument, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new UserEntity(fakerName, fakerEmail, 10, fakerCustomerDocument, fakerPhone));

        _mockMapper.Setup(m => m.Map<GetUserResult>(It.IsAny<UserEntity>()))
            .Returns((UserEntity e) => new GetUserResult()
            {
                Email = e.Email,
                Name = e.Name,
                Id = e.Id
            });
        
        var handler = new GetUserQueryHandler(_mockRepository.Object, _mockMapper.Object);

        var result = await handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        Assert.Equal(fakerName, result.Name);
        Assert.Equal(fakerEmail, result.Email);
    }
}