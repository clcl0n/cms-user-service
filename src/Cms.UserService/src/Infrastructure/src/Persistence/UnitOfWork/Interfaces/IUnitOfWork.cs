using Cms.UserService.Infrastructure.Persistence.Repositories.Interfaces;

namespace Cms.UserService.Infrastructure.Persistence.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
}
