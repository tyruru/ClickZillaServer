using Data;
using Repositories;

namespace Services;

public class EnemyService : BaseService<Enemy, EnemyRepository>
{
    public EnemyService(EnemyRepository repository) : base(repository)
    {
    }
    
    public async Task<Enemy> GetEnemyByNameAsync(string name)
    {
        return await _repository.GetByNameAsync(name);
    }
}