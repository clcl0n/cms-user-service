using Cms.UserService.Domain.Entities;
using Cms.UserService.Infrastructure.Persistence.Repositories.Base;
using Cms.UserService.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cms.UserService.Infrastructure.Persistence.Repositories;

internal sealed class UserRepository(DbContext dbContext)
    : BaseRepository<User>(dbContext),
        IUserRepository;
