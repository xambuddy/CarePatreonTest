using MediatR;

namespace CarePatreonTest.Application.Queries
{
    public class ReadClientsByKeywordQuery : IRequest<ReadClientsByKeywordQueryResponse>
    {
        public string Keyword { get; set; }
    }
}
