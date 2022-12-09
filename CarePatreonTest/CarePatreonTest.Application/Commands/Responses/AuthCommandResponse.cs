using System.Text.Json.Serialization;

namespace CarePatreonTest.Application.Commands.Responses
{
    public class AuthCommandResponse
    {
        public AuthCommandResponse(string userId, string name, string token)
        {
            UserId = userId;
            Name = name;
            Token = token;
        }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
