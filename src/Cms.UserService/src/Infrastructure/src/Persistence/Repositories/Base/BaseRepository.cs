using System;
using System.Threading;
using System.Threading.Tasks;
using Cms.UserService.Domain.Entities;
using Cms.UserService.Infrastructure.Persistence.Repositories.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cms.UserService.Infrastructure.Persistence.Repositories.Base;

internal abstract class BaseRepository<TEntity>(DbContext dbContext) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected DbSet<TEntity> Entities { get; } = dbContext.Set<TEntity>();

    protected DbContext DbContext { get; } = dbContext;

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToke)
    {
        return Entities.FirstOrDefaultAsync(x => x.Id == id, cancellationToke);
    }

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToke)
    {
        await Entities.AddAsync(entity, cancellationToke);

        await DbContext.SaveChangesAsync(cancellationToke);

        return entity with
        { };
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToke)
    {
        DbContext.Remove(new BaseEntity(id));

        await DbContext.SaveChangesAsync(cancellationToke);
    }
}
