using Xunit;

namespace User.UnitTests.Infra.Data;

public class UnitOfWorkTests
{
    [Fact]
    public async Task Commit_ShouldPersistChanges()
    {
        // Setup DbContext e UnitOfWork como no exemplo anterior
        // Adicione entidades ao contexto
        // Chame await unitOfWork.Commit(CancellationToken.None);
        // Verifique se as entidades foram persistidas corretamente
    }
}