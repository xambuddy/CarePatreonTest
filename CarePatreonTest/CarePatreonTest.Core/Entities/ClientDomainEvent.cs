using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Attributes;

namespace CarePatreonTest.Core.Entities
{
    [Container("client-events")]
    [PartitionKeyPath("/id")]
    public class ClientDomainEvent : FullItem
    {
        public ClientDomainEvent(Client data, string clientId, string action, IEnumerable<string> receiverIds)
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientId = clientId;
            this.Action = action;
            this.Data = data;
            this.ReceiverIds = receiverIds;
        }

        public Client Data { get; }

        public string ClientId { get; }

        public IEnumerable<string> ReceiverIds { get; }

        public string Action { get; }

        protected override string GetPartitionKeyValue()
        {
            return this.Id;
        }
    }
}
