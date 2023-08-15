using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserRegistration.DAL.Repositories;

namespace UserRegistration.DAL
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddUserRegistrationDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRegistrationRepository, RegistrationRepository>();

            return services;
        }
    }
}
