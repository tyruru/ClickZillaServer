using Data;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ClickZillaContext context) : base(context) { }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            var result = await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName);
            if (result == null)
                throw new Exception("Data not found");
            return result;
        }
        
    }
}
