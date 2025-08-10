using Data;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EnemyRepository : BaseRepository<Enemy>
    {
        public EnemyRepository(ClickZillaContext context) : base(context) { }
        
        public async Task<Enemy> GetByNameAsync(string name)
        {
            var result = await _dbSet.FirstOrDefaultAsync(e => e.Name == name);
            if (result == null)
                throw new Exception("Enemy not found");
            return result;
        }
    }
}
