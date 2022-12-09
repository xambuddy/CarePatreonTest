using AutoMapper;
using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Commands.Responses;
using CarePatreonTest.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarePatreonTest.API.Controllers
{
    /// <summary>
    /// Client Controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        private IMediator mediator;
        private IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public ClientController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CreateClientCommandResponse> CreateClient([FromBody] CreateClientDto request)
        {
            var createClientCommand = this.mapper.Map<CreateClientCommand>(request);

            var result = await this.mediator.Send(createClientCommand);

            return result;
        }

        /// <summary>
        /// Update Client
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<UpdateClientCommandResponse> UpdateClient([FromBody] UpdateClientDto request)
        {
            var updateClientCommand = this.mapper.Map<UpdateClientCommand>(request);

            var result = await this.mediator.Send(updateClientCommand);

            return result;
        }
    }
}
