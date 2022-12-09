using CarePatreonTest.Application.Commands.Responses;
using CarePatreonTest.Application.Common.Constants;
using CarePatreonTest.Application.Common.Interfaces;
using CarePatreonTest.Application.Exceptions;
using MediatR;

namespace CarePatreonTest.Application.Commands.Handlers
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthCommandResponse>
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IIdentityService _identityService;

        public AuthCommandHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
        {
            _identityService = identityService;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthCommandResponse> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.SigninUserAsync(request.UserName, request.Password);

            if (!result)
            {
                throw new BadRequestException(ApplicationConstants.Error_InvalidUserNameOrPassword);
            }

            var (userId, fullName, userName, email, roles) = await _identityService.GetUserDetailsAsync(await _identityService.GetUserIdAsync(request.UserName));

            string token = _tokenGenerator.GenerateToken((userId: userId, userName: userName, roles: roles));

            return new AuthCommandResponse(userId, userName, token);
        }
    }
}
