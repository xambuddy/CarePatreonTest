using CarePatreonTest.Application.Models;
using System.Text.Json.Serialization;

namespace CarePatreonTest.Application.Commands.Responses
{
    public class CreateClientCommandResponse
    {
        public CreateClientCommandResponse(ClientDto clientDto)
        {
            this.Client = clientDto;
        }

        [JsonPropertyName("client")]
        public ClientDto Client { get; set; }
    }
}
