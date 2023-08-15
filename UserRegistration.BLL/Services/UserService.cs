using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UserRegistration.BLL.Models.Registration;
using UserRegistration.DAL.Models;
using UserRegistration.DAL.Repositories;

namespace UserRegistration.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public UserService(IMapper mapper, IRegistrationRepository registrationRepository, IPasswordHasher<UserEntity> passwordHasher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _registrationRepository = registrationRepository ?? throw new ArgumentNullException(nameof(registrationRepository));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public RegistrationResultModel CreateUser(RegistrationModel command)
        {
            if (_registrationRepository.GetUserByEmail(command.Email) != null)
            {
                throw new ValidationException("User with this email already exists") { Source = "Email" };
            }

            var hashedPassword = _passwordHasher.HashPassword(null, command.Password);
            var result = _registrationRepository.Create(command.Login, command.Email, hashedPassword);

            return _mapper.Map<RegistrationResultModel>(result);
        }
    }
}
