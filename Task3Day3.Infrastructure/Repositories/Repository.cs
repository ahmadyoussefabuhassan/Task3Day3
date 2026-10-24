using Microsoft.EntityFrameworkCore;
using Task3Day3.Domain.Abstractions;

namespace Task3Day3.Infrastructure.Repositories
{
    internal  class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext _dbContext;
        protected Repository(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
            if (entity is not null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);

        public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
