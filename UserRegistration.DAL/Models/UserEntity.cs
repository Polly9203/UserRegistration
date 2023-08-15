namespace UserRegistration.DAL.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
