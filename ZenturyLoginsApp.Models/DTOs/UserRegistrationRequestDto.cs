using System.ComponentModel.DataAnnotations;

namespace ZenturyLoginsApp.Models.DTOs
{
    public class UserRegistrationRequestDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
