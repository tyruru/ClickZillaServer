using Data;

namespace Repositories
{
    public class EnemyRepository : BaseRepository<Enemy>
    {
        public EnemyRepository(ClickZillaContext context) : base(context) { }
    }
}
