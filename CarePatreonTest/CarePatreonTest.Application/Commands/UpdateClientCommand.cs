using CarePatreonTest.Application.Commands.Responses;
using MediatR;

namespace CarePatreonTest.Application.Commands
{
    public class UpdateClientCommand : IRequest<UpdateClientCommandResponse>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
    }
}
