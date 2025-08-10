using Data;

namespace Repositories
{
    public class LocationRepository : BaseRepository<Location>
    {
        public LocationRepository(ClickZillaContext context) : base(context) { }
        
        
    }
}
