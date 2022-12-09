// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using Azure.Messaging.EventGrid;
using CarePatreonTest.Core.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Chats.Functions.Channels
{
    public class ClientsSignalROutputEventGridTriggerFunction
    {
        [FunctionName("ClientsSignalROutputEventGridTriggerFunction")]
        public async Task Run([EventGridTrigger] EventGridEvent eventGridEvent,
            [SignalR(HubName = "notificationHub")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());

            var data = eventGridEvent.Data.ToObjectFromJson<ClientDomainEvent>();

            foreach (var id in data.ReceiverIds)
            {
                var signalREvent =
                    new SignalRMessage
                    {
                        Target = data.Action,
                        UserId = id,
                        Arguments = new[] { data.Data }
                    };

                await signalRMessages.AddAsync(signalREvent);
            }
        }
    }
}
