using System.ComponentModel.DataAnnotations;

namespace ZenturyLoginsApp.Models.Entities
{
    public class User
    {
        public User()
        {
            Logins = new HashSet<Login>();    
        }

        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
