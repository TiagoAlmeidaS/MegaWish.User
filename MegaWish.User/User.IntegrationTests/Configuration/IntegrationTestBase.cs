using Microsoft.EntityFrameworkCore;
using User.Infra.Data;

namespace User.IntegrationTests.Configuration;

public class IntegrationTestBase
{
    protected UserDBContext CreateDbContextInMemory()
    {
        var options = new DbContextOptionsBuilder<UserDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var dbContext = new UserDBContext(options);
        dbContext.Database.EnsureCreated();

        return dbContext;
    }
}