using System.Threading;
using System.Threading.Tasks;
using Cms.UserService.Infrastructure.Persistence;
using Cms.UserService.Infrastructure.Services.Interfaces;

namespace Cms.UserService.Infrastructure.Services;

internal sealed class PersistenceService(UserDbContext dbContext) : IPersistenceService
{
    public Task ApplyMigrationsAsync(CancellationToken cancellationToken)
    {
        return dbContext.ApplyMigrations(cancellationToken);
    }
}
