using System.ComponentModel.DataAnnotations;

namespace The_Breadpit.Models
{
    public enum AccountRole {user, manager, admin}
    public class AccountLoginResponse
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string? Password { get; set; }

        public AccountRole Role { get; set; } = AccountRole.user;
    }
}
