using CGM.Api.Controllers;
using CGM.CashExchange.Core.Application.Contracts.Dtos.Api;
using CGM.CashExchange.Core.Application.Contracts.Response;
using CGM.CashExchange.Core.Application.Features.Operacion.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CGM.CashExchange.EntryPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : BaseController
    {
        [HttpPost("Registrar")]
        public async Task<OkResponse<OperacionDto>> Registrar([FromBody] CrearOperacionCommand busqueda)
        {
            return await Mediator.Send(busqueda);
        }
    }
}
