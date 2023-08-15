using UserRegistration.DAL.Models;

namespace UserRegistration.DAL.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationContext _applicationContext;
        public RegistrationRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public UserEntity Create(string login, string email, string password)
        {
            var user = new UserEntity() { Login = login, Email = email, Password = password };
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();

            return user;
        }

        public UserEntity GetUserByEmail(string email)
        {
            var user = _applicationContext.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }
    }
}
