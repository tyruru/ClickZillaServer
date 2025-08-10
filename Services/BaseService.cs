using Data;
using Repositories;

namespace Services;

public class BaseService<TEntity, TRepository> : IService<TEntity> 
    where TEntity : IEntity 
    where TRepository : IRepository<TEntity>
{
    protected readonly TRepository _repository;
    
    protected BaseService(TRepository repository)
    {
        _repository = repository;
    }
    
    public Task<TEntity> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("ID cannot be empty.", nameof(id));
        
        return _repository.GetByIdAsync(id);
    }
    
    public Task<List<TEntity>> GetAllAsync()
    {
        return _repository.GetAllAsync();  
    }

    public Task AddAsync(TEntity entity)
    {
        
       return _repository.AddAsync(entity);
    }

    public Task UpdateAsync(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
        
        return _repository.UpdateAsync(entity);
    }

    public Task DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }
    
}