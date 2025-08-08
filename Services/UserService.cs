using System.Security.Cryptography;
using System.Text;
using ClickZillaServer.Models;
using Repositories;

namespace Services
{
    public class UserService 
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserAsync(string name)
        {
            return await _userRepository.GetByNameAsync(name);
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<bool> AuthorizeAsync(string userName, string password)
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(u => u.UserName == userName);
            if (user == null) return false;
            var hash = HashPassword(password);
            return user.Password == hash;
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
