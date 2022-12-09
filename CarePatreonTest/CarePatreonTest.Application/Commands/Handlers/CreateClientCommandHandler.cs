using AutoMapper;
using CarePatreonTest.Application.Commands.Responses;
using CarePatreonTest.Application.Exceptions;
using CarePatreonTest.Application.Models;
using CarePatreonTest.Core.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Azure.CosmosRepository;

namespace CarePatreonTest.Application.Commands.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientCommandResponse>
    {
        private IRepository<Client> clientRepository;
        private IRepository<ClientDomainEvent> clientDomainEventRepository;
        private IValidator<CreateClientCommand> createClientCommandValidator;
        private IMapper mapper;
        public CreateClientCommandHandler(
            IRepository<Client> clientRepository, 
            IRepository<ClientDomainEvent> clientDomainEventRepository,
            IValidator<CreateClientCommand> createClientCommandValidator,
            IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.clientDomainEventRepository = clientDomainEventRepository;
            this.createClientCommandValidator = createClientCommandValidator;
            this.mapper = mapper;
        }

        public async Task<CreateClientCommandResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var validationResult = this.createClientCommandValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors?.FirstOrDefault()?.ErrorMessage);
            }

            var client = this.mapper.Map<Client>(request);

            client = await this.clientRepository.CreateAsync(client, cancellationToken);

            await this.clientDomainEventRepository.CreateAsync(
                new ClientDomainEvent(client, client.Id, "ClientCreated"),
                cancellationToken);

            var clientDto = this.mapper.Map<ClientDto>(client);

            return new CreateClientCommandResponse(clientDto);
        }
    }
}
