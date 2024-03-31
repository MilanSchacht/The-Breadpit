namespace The_Breadpit.Models
{
    public enum AccountRole { user, manager, admin }
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountRole Role { get; set; }
    }
}
