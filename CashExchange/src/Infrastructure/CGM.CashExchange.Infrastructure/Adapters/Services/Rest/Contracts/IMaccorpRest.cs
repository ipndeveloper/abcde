using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Request;
using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Infrastructure.Adapters.Services.Rest.Contracts
{
    public interface IMaccorpRest
    {
        [Get("/jugador?documento={documento}&fecha-nacimiento={fechanacimiento}")]
        Task<MaccorpResponseDto<DataConsultaDto>> GetObtenerFichaCliente(string documento, string fechanacimiento);

        [Post("/operacion")]
        Task<MaccorpResponseDto<DataCrearOperacionDto>> PostCrearOperacion([Body] CrearOperacionDto operacion);


        [Post("/recibo")]
        Task<MaccorpResponseDto<DataReciboEnviadoDto>> PostEnviarRecibo([Body] EnviarReciboDto recibo);
    }
}
