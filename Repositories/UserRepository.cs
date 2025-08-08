using ClickZillaServer.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class UserRepository
    {
        private readonly ClickZillaContext _context;
        private readonly DbSet<User> _dbSet;
        
        public UserRepository(ClickZillaContext context)
        {
            _dbSet = context.Set<User>();
            _context = context;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var result = await _dbSet
                .FirstOrDefaultAsync(entity => entity.Id == id);

            if (result == null)
                throw new Exception("Data not found");

            return result;
        }

        public async Task<User> GetByNameAsync(string name)
        {
            var result = await _dbSet
                .FirstOrDefaultAsync(entity => entity.UserName == name);

            if (result == null)
                throw new Exception("Data not found");

            return result;
        }
        
        public async Task<List<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

