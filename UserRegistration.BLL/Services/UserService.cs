using AutoMapper;
using UserRegistration.BLL.Models.Registration;
using UserRegistration.DAL.Repositories;

namespace UserRegistration.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRegistrationRepository _registrationRepository;

        public UserService(IMapper mapper, IRegistrationRepository registrationRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _registrationRepository = registrationRepository ?? throw new ArgumentNullException(nameof(registrationRepository));
        }

        public RegistrationResultModel CreateUser(RegistrationModel command)
        {

            var result = _registrationRepository.Create(command.Login, command.Email, command.Password);
            return _mapper.Map<RegistrationResultModel>(result);
        }
    }
}
