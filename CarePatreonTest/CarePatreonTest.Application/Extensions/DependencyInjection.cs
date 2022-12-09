using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CarePatreonTest.Application.Extensions
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<CreateClientCommand>, CreateClientCommandValidator>();
            services.AddSingleton<IValidator<UpdateClientCommand>, UpdateClientCommandValidator>();
        }
    }
}
