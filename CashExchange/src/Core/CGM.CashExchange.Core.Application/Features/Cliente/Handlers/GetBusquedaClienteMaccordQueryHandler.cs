using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response;
using CGM.CashExchange.Core.Application.Contracts.Ports.Services.Rest;
using CGM.CashExchange.Core.Application.Contracts.Response;
using CGM.CashExchange.Core.Application.Features.Cliente.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Features.Cliente.Handlers
{
    public class GetBusquedaClienteMaccordQueryHandler : IRequestHandler<GetBusquedaClienteMaccordQuery, OkResponse<UserDto>>
    {
        protected IMaccorpService _maccorpService;
        public GetBusquedaClienteMaccordQueryHandler(IMaccorpService maccorpService)
        {
            _maccorpService = maccorpService;
        }
        public async Task<OkResponse<UserDto>> Handle(GetBusquedaClienteMaccordQuery request, CancellationToken cancellationToken)
        {
            var response = await _maccorpService.ConsultalientAsync(request.Documento, request.FechaNacimiento);
            return OkResponse<UserDto>.Ok(response);
        }
    }
}
