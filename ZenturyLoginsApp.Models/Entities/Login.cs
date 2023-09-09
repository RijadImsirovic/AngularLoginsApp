namespace ZenturyLoginsApp.Models.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime LoginAttemptAt { get; set; } = DateTime.UtcNow;

        public virtual User User { get; set; }
    }
}
