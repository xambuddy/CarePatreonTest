using AutoMapper;
using CarePatreonTest.Application.Commands.Responses;
using CarePatreonTest.Application.Exceptions;
using CarePatreonTest.Application.Models;
using CarePatreonTest.Core.Entities;
using CarePatreonTest.Core.Enums;
using FluentValidation;
using MediatR;
using Microsoft.Azure.CosmosRepository;

namespace CarePatreonTest.Application.Commands.Handlers
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, UpdateClientCommandResponse>
    {
        private IRepository<Client> clientRepository;
        private IRepository<ClientDomainEvent> clientDomainEventRepository;
        private IValidator<UpdateClientCommand> updateClientCommandValidator;
        private IMapper mapper;
        public UpdateClientCommandHandler(
            IRepository<Client> clientRepository,
            IRepository<ClientDomainEvent> clientDomainEventRepository,
            IValidator<UpdateClientCommand> updateClientCommandValidator,
            IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.clientDomainEventRepository = clientDomainEventRepository;
            this.updateClientCommandValidator = updateClientCommandValidator;
            this.mapper = mapper;
        }

        public async Task<UpdateClientCommandResponse> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var validationResult = this.updateClientCommandValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors?.FirstOrDefault()?.ErrorMessage);
            }

            var existingClient = await this.clientRepository.TryGetAsync(request.Id, cancellationToken: cancellationToken);

            if (existingClient == null)
            {
                return new UpdateClientCommandResponse(null);
            }

            var client = this.mapper.Map<Client>(request);

            client.Id = request.Id;

            client = await this.clientRepository.UpdateAsync(client, cancellationToken);

            await this.clientDomainEventRepository.CreateAsync(
                new ClientDomainEvent(client, client.Id, nameof(DomainEventTypes.ClientUpdated), new List<string> { request.UserId }), 
                cancellationToken);

            var clientDto = this.mapper.Map<ClientDto>(client);

            return new UpdateClientCommandResponse(clientDto);
        }
    }
}
