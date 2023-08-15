using AutoMapper;
using UserRegistration.BLL.Models.Registration;
using UserRegistration.DAL.Models;

namespace UserRegistration.BLL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, RegistrationResultModel>();
        }
    }
}
