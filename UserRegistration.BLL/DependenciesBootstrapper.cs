using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserRegistration.BLL.Registration.Commands;

namespace UserRegistration.BLL
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddUserRegistrationBLL(this IServiceCollection services)
        {
            services.AddSingleton(AutoMapperInitialization.CreateMapper());
            services.AddTransient<IRegistrationCommandHandler, RegistrationCommandHandler>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
