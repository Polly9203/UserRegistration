using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UserRegistration.BLL.MappingProfiles;
using UserRegistration.BLL.Services;
using UserRegistration.DAL.Models;

namespace UserRegistration.BLL
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddUserRegistrationBLL(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;

                cfg.AddProfile<UserProfile>();
            });

            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();

            return services;
        }
    }
}
