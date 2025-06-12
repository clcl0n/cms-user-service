using System.Threading;
using System.Threading.Tasks;
using Cms.Cli.Commands.Interfaces;
using Cms.UserService.Infrastructure.Services.Interfaces;

namespace Cms.UserService.Cli.Commands;

public class ApplyMigrationsCommand(IPersistenceService persistenceService) : ICommand
{
    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        return persistenceService.ApplyMigrationsAsync(cancellationToken);
    }
}
