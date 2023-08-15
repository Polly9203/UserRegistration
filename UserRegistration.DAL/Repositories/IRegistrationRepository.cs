using UserRegistration.DAL.Models;

namespace UserRegistration.DAL.Repositories
{
    public interface IRegistrationRepository
    {
        UserEntity Create(string login, string email, string password);
    }
}
