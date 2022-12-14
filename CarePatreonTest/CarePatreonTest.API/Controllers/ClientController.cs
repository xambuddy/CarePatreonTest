using AutoMapper;
using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Commands.Responses;
using CarePatreonTest.Application.Models;
using CarePatreonTest.Application.Queries;
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
            var userId = this.User?.Identity?.Name;
            createClientCommand.UserId = userId;

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
            var userId = this.User?.Identity?.Name;
            updateClientCommand.UserId = userId;

            var result = await this.mediator.Send(updateClientCommand);

            return result;
        }

        /// <summary>
        /// Search Clients
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReadClientsByKeywordQueryResponse> SearchClient(string keyword)
        {
            var query = new ReadClientsByKeywordQuery
            {
                Keyword = keyword
            };

            var result = await this.mediator.Send(query);

            return result;
        }
    }
}
