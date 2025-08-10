using System.Security.Cryptography;
using System.Text;
using Data;
using Repositories;

namespace Services
{
    public class UserService : BaseService<User, UserRepository>
    {

        public UserService(UserRepository userRepository) : base(userRepository)
        {
        }

      

        public async Task<User> GetUserAsync(string name)
        {
            return await _repository.GetByUserNameAsync(name);
        }
       

        public async Task<bool> AuthorizeAsync(string userName, string password)
        {
            var users = await _repository.GetAllAsync();
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
