using CarePatreonTest.Application.Models;

namespace CarePatreonTest.Application.Queries
{
    public record ReadClientsByKeywordQueryResponse(IList<ClientDto> Clients)
    {
        public IList<ClientDto> Clients { get; set; } = Clients;
    }
}
