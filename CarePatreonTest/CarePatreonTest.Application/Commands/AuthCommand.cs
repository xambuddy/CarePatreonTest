using CarePatreonTest.Application.Commands.Responses;
using MediatR;

namespace CarePatreonTest.Application.Commands
{
    public class AuthCommand : IRequest<AuthCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
