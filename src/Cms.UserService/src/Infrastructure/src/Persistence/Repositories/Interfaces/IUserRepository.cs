using Cms.UserService.Domain.Entities;
using Cms.UserService.Infrastructure.Persistence.Repositories.Base.Interfaces;

namespace Cms.UserService.Infrastructure.Persistence.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>;
