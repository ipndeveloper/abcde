using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Request;
using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response;
using CGM.CashExchange.Core.Application.Contracts.Ports.Services.Rest;
using CGM.CashExchange.Core.Application.Contracts.Response;
using CGM.CashExchange.Core.Application.Exceptions;
using CGM.CashExchange.Infrastructure.Adapters.Services.Rest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Infrastructure.Adapters.Services.Rest
{
    public class MaccorpService : IMaccorpService
    {
        protected IMaccorpRest _maccorpRest;
        public MaccorpService(IMaccorpRest maccorpRest)
        {
            _maccorpRest = maccorpRest;
        }
        public int CancelarOperacionAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DataReciboEnviadoDto> EnviarReciboAsync(EnviarReciboDto recibo)
        {
            var response = await _maccorpRest.PostEnviarRecibo(recibo);
            if (!response.success)
            {
                var errors = string.Join(",", response.errors);
                throw new InfrastructureLayerException($"ApiMaccorp - Error al enviar recibo : {errors}");
            }

            return response.data;
        }
        public async Task<UserDto> ConsultalientAsync(string numeroDocumento, string fechaNacimiento)
        {
            var response = await _maccorpRest.GetObtenerFichaCliente( numeroDocumento,  fechaNacimiento);
            if (!response.success)
            {
                var errors = string.Join(",", response.errors);
                throw new InfrastructureLayerException($"ApiMaccorp - Error al consultar jugador : {errors}");
            }
            return response.data.user;
        }

        public async Task<DataCrearOperacionDto> CreateOperacionAsync(CrearOperacionDto operacion)
        {
            var response = await _maccorpRest.PostCrearOperacion(operacion);
            if (!response.success)
            {
                var errors = string.Join(",", response.errors);
                throw new InfrastructureLayerException($"ApiMaccorp - Error al crear la operación: {errors}");
            }
                
            return response.data;
        }

        public int CreateFichaClientAsync()
        {
            throw new NotImplementedException();
        }

        public int UpdateClientAsync()
        {
            throw new NotImplementedException();
        }

        public int GetRecibosPendientesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
