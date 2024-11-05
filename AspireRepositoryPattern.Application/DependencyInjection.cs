using Application.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IRequestValidator<>), typeof(RequestValidator<>));

            var thisAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(thisAssembly);
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(thisAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(thisAssembly));

            return services;
        }
    }
}
