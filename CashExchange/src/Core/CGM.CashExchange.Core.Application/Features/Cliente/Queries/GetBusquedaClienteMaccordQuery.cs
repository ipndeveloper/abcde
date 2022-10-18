using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response;
using CGM.CashExchange.Core.Application.Contracts.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Features.Cliente.Queries
{
    public class GetBusquedaClienteMaccordQuery : IRequest<OkResponse<UserDto>>
    {
        public string Documento { get; set; }
        public string FechaNacimiento { get; set; }
    }
}
