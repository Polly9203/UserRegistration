using UserRegistration.BLL.Models.Registration;

namespace UserRegistration.BLL.Services
{
    public interface IUserService
    {
        public RegistrationResultModel CreateUser(RegistrationModel command);
    }
}
