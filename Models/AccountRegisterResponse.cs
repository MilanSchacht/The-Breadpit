using System.ComponentModel.DataAnnotations;

namespace The_Breadpit.Models
{
    public class AccountRegisterResponse : AccountLoginResponse
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
