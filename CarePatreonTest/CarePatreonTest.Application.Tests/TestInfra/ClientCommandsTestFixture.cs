using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Commands.Handlers;
using CarePatreonTest.Application.Profiles;
using CarePatreonTest.Application.Validators;
using CarePatreonTest.Core.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Extensions.DependencyInjection;

namespace CarePatreonTest.Application.Tests.TestInfra
{
    public class ClientCommandsTestFixture : IDisposable
    {
        public ServiceProvider Provider { get; }

        public ClientCommandsTestFixture()
        {
            Provider = new ServiceCollection()
                .AddScoped<IRepository<Client>, InMemoryClientRepository>()
                .AddScoped<IRepository<ClientDomainEvent>, InMemoryClientDomainEventRepository>()
                .AddScoped<IValidator<CreateClientCommand>, CreateClientCommandValidator>()
                .AddScoped<IValidator<UpdateClientCommand>, UpdateClientCommandValidator>()
                .AddAutoMapper(typeof(ClientProfile))
                .AddMediatR(typeof(Client), typeof(CreateClientCommandHandler), typeof(CreateClientCommand))
                .BuildServiceProvider();
        }

        public void Dispose()
        {

        }
    }
}
