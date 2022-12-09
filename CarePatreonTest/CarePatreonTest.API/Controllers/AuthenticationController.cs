using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarePatreonTest.API.Controllers
{
    /// <summary>
    /// Authentication Controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AuthCommandResponse> Login([FromBody] AuthCommand command)
        {
            return await this.mediator.Send(command);
        }
    }
}
