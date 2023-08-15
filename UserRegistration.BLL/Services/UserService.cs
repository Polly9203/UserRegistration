using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using UserRegistration.BLL.Models;
using UserRegistration.BLL.Models.Registration;
using UserRegistration.DAL.Models;
using UserRegistration.DAL.Repositories;

namespace UserRegistration.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly EmailValidationSettings _emailValidationSettings;

        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IRegistrationRepository _registrationRepository;

        public UserService(IOptions<EmailValidationSettings> emailValidationSettings, IMapper mapper, IPasswordHasher<UserEntity> passwordHasher, IRegistrationRepository registrationRepository)
        {
            _emailValidationSettings = emailValidationSettings.Value;

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _registrationRepository = registrationRepository ?? throw new ArgumentNullException(nameof(registrationRepository));
        }

        public RegistrationResultModel CreateUser(RegistrationModel command)
        {
            if (_registrationRepository.GetUserByEmail(command.Email) != null)
            {
                throw new ValidationException(_emailValidationSettings.ErrorMessage) { Source = _emailValidationSettings.PropertyName};
            }

            var hashedPassword = _passwordHasher.HashPassword(null, command.Password);
            var result = _registrationRepository.Create(command.Login, command.Email, hashedPassword);

            return _mapper.Map<RegistrationResultModel>(result);
        }
    }
}
