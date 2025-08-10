using Data;

namespace Repositories;

public interface IRepository<TEntity> where TEntity : IEntity
{
    public Task<TEntity> GetByIdAsync(Guid id);

    public Task<List<TEntity>> GetAllAsync();
    public Task AddAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(Guid id);
}