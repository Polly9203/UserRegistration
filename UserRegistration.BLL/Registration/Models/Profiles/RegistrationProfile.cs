using AutoMapper;
using UserRegistration.DAL.Models;

namespace UserRegistration.BLL.Registration.Models.Profiles
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<UserModel, RegistrationResult>();
        }
    }
}
