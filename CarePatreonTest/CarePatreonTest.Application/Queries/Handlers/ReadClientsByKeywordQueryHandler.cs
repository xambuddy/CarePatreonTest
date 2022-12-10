using AutoMapper;
using CarePatreonTest.Application.Exceptions;
using CarePatreonTest.Application.Models;
using CarePatreonTest.Application.Specifications;
using CarePatreonTest.Core.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Azure.CosmosRepository;

namespace CarePatreonTest.Application.Queries
{
    public class ReadClientsByKeywordQueryHandler : IRequestHandler<ReadClientsByKeywordQuery, ReadClientsByKeywordQueryResponse>
    {
        private readonly IRepository<Client> clientRepository;
        private readonly IValidator<ReadClientsByKeywordQuery> readClientsByKeywordQueryValidator;
        private readonly IMapper mapper;

        public ReadClientsByKeywordQueryHandler(
            IRepository<Client> clientRepository,
            IValidator<ReadClientsByKeywordQuery> readClientsByKeywordQueryValidator,
            IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.readClientsByKeywordQueryValidator = readClientsByKeywordQueryValidator;
            this.mapper = mapper;
        }

        public async Task<ReadClientsByKeywordQueryResponse> Handle(ReadClientsByKeywordQuery request, CancellationToken cancellationToken)
        {
            var validationResult = this.readClientsByKeywordQueryValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors?.FirstOrDefault()?.ErrorMessage);
            }

            var clientsByKeywordSpec = new ClientsByKeywordSpec(request.Keyword);

            var noResults = false;
            var results = new List<Client>();
            while (!noResults)
            {
                var page = await this.clientRepository.QueryAsync(clientsByKeywordSpec, cancellationToken: cancellationToken);

                results.AddRange(page.Items);
                if (page.Continuation == null)
                {
                    noResults = true;
                }

                clientsByKeywordSpec.UpdateContinuationToken(page.Continuation);
            }

            var clientDtos = this.mapper.Map<IList<ClientDto>>(results);

            return new ReadClientsByKeywordQueryResponse(clientDtos);
        }
    }
}
