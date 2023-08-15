using UserRegistration.BLL.Registration.Models;

namespace UserRegistration.BLL.Registration.Commands
{
    public interface IRegistrationCommandHandler
    {
        public RegistrationResult RegistrateUser(RegistrationCommand command);
    }
}
