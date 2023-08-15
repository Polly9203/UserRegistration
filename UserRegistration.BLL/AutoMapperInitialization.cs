using AutoMapper;
using UserRegistration.BLL.Registration.Models.Profiles;

namespace UserRegistration.BLL
{
    public static class AutoMapperInitialization
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;

                cfg.AddProfile<RegistrationProfile>();
            }).CreateMapper();
        }
    }
}
