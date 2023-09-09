namespace ZenturyLoginsApp.Models.DTOs
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime LoginAttemptAt { get; set; }

        public UserDto User { get; set; }
    }
}
