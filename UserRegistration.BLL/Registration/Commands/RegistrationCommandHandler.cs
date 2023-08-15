using AutoMapper;
using UserRegistration.BLL.Registration.Models;
using UserRegistration.DAL.Repositories;

namespace UserRegistration.BLL.Registration.Commands
{
    public class RegistrationCommandHandler : IRegistrationCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationCommandHandler(IMapper mapper, IRegistrationRepository registrationRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _registrationRepository = registrationRepository ?? throw new ArgumentNullException(nameof(registrationRepository));
        }

        public RegistrationResult RegistrateUser(RegistrationCommand command)
        {
            var result = _registrationRepository.Registrate(command.Login, command.Email, command.Password);
            return _mapper.Map<RegistrationResult>(result);
        }
    }
}
