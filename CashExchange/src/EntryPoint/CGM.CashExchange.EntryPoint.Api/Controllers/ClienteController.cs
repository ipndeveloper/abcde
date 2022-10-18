using CGM.Api.Controllers;
using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response;
using CGM.CashExchange.Core.Application.Contracts.Response;
using CGM.CashExchange.Core.Application.Features.Cliente.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CGM.CashExchange.EntryPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController
    {
        [HttpGet("Buscar")]
 
        public async Task<OkResponse<UserDto>> Index([FromQuery] GetBusquedaClienteMaccordQuery busqueda)
        {
            return await Mediator.Send(busqueda);
          
        }
    }
}
