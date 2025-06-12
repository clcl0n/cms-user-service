using System;
using System.Threading;
using System.Threading.Tasks;
using Cms.UserService.Domain.Entities;

namespace Cms.UserService.Infrastructure.Persistence.Repositories.Base.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToke);

    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToke);

    public Task DeleteAsync(Guid id, CancellationToken cancellationToke);
}
