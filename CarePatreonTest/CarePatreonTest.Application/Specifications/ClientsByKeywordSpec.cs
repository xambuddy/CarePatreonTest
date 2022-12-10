using CarePatreonTest.Core.Entities;
using Microsoft.Azure.CosmosRepository.Specification;

namespace CarePatreonTest.Application.Specifications
{
    public class ClientsByKeywordSpec : ContinuationTokenSpecification<Client>
    {
        public ClientsByKeywordSpec(string keyword)
        {
            Query.Where(x =>
                    x.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                    x.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                    x.PhoneNumber.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    x.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase)).PageSize(100);
        }
    }
}
