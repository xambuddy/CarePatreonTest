using Azure.Messaging.EventGrid;
using CarePatreonTest.Core.Entities;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarePatreonTest.Functions
{
    public class ClientsCosmosDbTriggerFunction
    {
        [FunctionName("ClientsCosmosDbTriggerFunction")]
        public async Task Run([CosmosDBTrigger(
            databaseName: "carepatreontest",
            collectionName: "client-events",
            CreateLeaseCollectionIfNotExists = true,
            FeedPollDelay = 1000,
            ConnectionStringSetting = "CosmosDBConnection",
            LeaseCollectionName = "client-events-leases")]IReadOnlyList<Document> input,
            [EventGrid(TopicEndpointUri = "ClientEventGridEndpoint", TopicKeySetting = "ClientEventGridKey")] IAsyncCollector<EventGridEvent> eventCollector,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                foreach (var document in input)
                {
                    log.LogInformation("Processing a document");
                    try
                    {
                        var eventGridEvent = new EventGridEvent("IncomingRequest", "IncomingRequest", "1.0.0", JsonConvert.DeserializeObject<ClientDomainEvent>(document.ToString()));

                        log.LogInformation(JsonConvert.SerializeObject(eventGridEvent));
                        await eventCollector.AddAsync(eventGridEvent);
                    }
                    catch (Exception ex)
                    {
                        log.LogError(ex.ToString());
                    }
                }
            }
        }
    }
}
