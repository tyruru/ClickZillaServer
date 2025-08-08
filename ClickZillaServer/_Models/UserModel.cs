namespace ClickZillaServer.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int? UserExp { get; set; }
        public int? EnemiesKilled { get; set; }
    }
}
