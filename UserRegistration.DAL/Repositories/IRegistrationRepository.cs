using UserRegistration.DAL.Models;

namespace UserRegistration.DAL.Repositories
{
    public interface IRegistrationRepository
    {
        UserModel Registrate(string login, string email, string password);
    }
}
