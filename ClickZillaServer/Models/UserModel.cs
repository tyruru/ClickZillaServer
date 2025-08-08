namespace ClickZillaServer.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int? UserExp { get; set; }
        public int? EnemiesKilled { get; set; }
    }

    public class UserRegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    public class UserAuthorizeRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }
        public int? UserExp { get; set; }
        public int? EnemiesKilled { get; set; }
    }
}
