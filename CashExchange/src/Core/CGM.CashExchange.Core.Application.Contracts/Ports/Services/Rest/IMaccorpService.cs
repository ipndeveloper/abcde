using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Request;
using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response;
using CGM.CashExchange.Core.Application.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Contracts.Ports.Services.Rest
{
    public interface IMaccorpService
    {
        Task<UserDto> ConsultalientAsync(string numeroDocumento, string fechaNacimiento);
        int CreateFichaClientAsync();
        int UpdateClientAsync();
        Task<DataCrearOperacionDto> CreateOperacionAsync(CrearOperacionDto operacion);
        
        int CancelarOperacionAsync();

        Task<DataReciboEnviadoDto> EnviarReciboAsync(EnviarReciboDto recibo);

        int GetRecibosPendientesAsync();
    }
}
