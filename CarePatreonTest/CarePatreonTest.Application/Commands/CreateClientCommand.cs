using CarePatreonTest.Application.Commands.Responses;
using MediatR;

namespace CarePatreonTest.Application.Commands
{
    public class CreateClientCommand : IRequest<CreateClientCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
    }
}
