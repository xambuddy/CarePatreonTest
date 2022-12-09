using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Attributes;

namespace CarePatreonTest.Core.Entities
{
    [PartitionKeyPath("/id")]
    [Container("clients")]
    public class Client : FullItem
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
