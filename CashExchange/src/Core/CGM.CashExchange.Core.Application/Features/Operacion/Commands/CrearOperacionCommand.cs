using CGM.CashExchange.Core.Application.Contracts.Dtos.Api;
using CGM.CashExchange.Core.Application.Contracts.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Features.Operacion.Commands
{
    public class CrearOperacionCommand : IRequest<OkResponse<OperacionDto>>
    {
        public string Token { get; set; }
        public int TipoOperacionCGM { get; set; }
        public string TipoOperacionMaccord { get; set; }
        public string DeclaracionCasual { get; set; }


        public decimal Monto { get; set; }
        public int IdCajero { get; set; }

        public string NombreApellido { get; set; }

        public string Documento { get; set; }

        public string Direccion { get; set; }

        public string PaisResidencia { get; set; }
        public string Telefono { get; set; }
        public string AgenteMaccorp { get; set; }

        public string NroCuentaDePago { get; set; }
    }
}
