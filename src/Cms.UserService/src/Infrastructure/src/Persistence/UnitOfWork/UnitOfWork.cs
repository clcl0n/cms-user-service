using System;
using Cms.UserService.Infrastructure.Persistence.Repositories;
using Cms.UserService.Infrastructure.Persistence.Repositories.Interfaces;
using Cms.UserService.Infrastructure.Persistence.UnitOfWork.Interfaces;

namespace Cms.UserService.Infrastructure.Persistence.UnitOfWork;

internal sealed class UnitOfWork(UserDbContext dbContext) : IUnitOfWork
{
    public IUserRepository UserRepository => _lazyUserRepository.Value;

    private readonly Lazy<IUserRepository> _lazyUserRepository = new(
        () => new UserRepository(dbContext)
    );
}
