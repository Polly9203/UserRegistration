using Microsoft.EntityFrameworkCore;
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

        public UserModel Registrate(string login, string email, string password)
        {
            if (_applicationContext.Users.Any(u => u.Email == email))
            {
                throw new DbUpdateException("User with this email already exists.");
            }

            var user = new UserModel() { Login = login, Email = email, Password = password };
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();

            return user;
        }
    }
}
