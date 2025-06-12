using System.Threading;
using System.Threading.Tasks;

namespace Cms.UserService.Infrastructure.Services.Interfaces;

public interface IPersistenceService
{
    Task ApplyMigrationsAsync(CancellationToken cancellationToken);
}
