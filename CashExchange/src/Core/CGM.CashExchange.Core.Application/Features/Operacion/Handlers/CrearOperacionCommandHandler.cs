using CGM.CashExchange.Core.Application.Contracts.Dtos.Api;
using CGM.CashExchange.Core.Application.Contracts.Dtos.Reports;
using CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Request;
using CGM.CashExchange.Core.Application.Contracts.Ports.Services.Reports;
using CGM.CashExchange.Core.Application.Contracts.Ports.Services.Rest;
using CGM.CashExchange.Core.Application.Contracts.Response;
using CGM.CashExchange.Core.Application.Features.Operacion.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Features.Operacion.Handlers
{
    public class CrearOperacionCommandHandler : IRequestHandler<CrearOperacionCommand, OkResponse<OperacionDto>>
    {
        protected IMaccorpService _maccordService;
        protected IPdfService _pdfService;

       
        public CrearOperacionCommandHandler(IMaccorpService maccordService, 
                                            IPdfService pdfService)
        {
            _maccordService = maccordService;
            _pdfService = pdfService;
        }
        public async Task<OkResponse<OperacionDto>> Handle(CrearOperacionCommand request, CancellationToken cancellationToken)
        {
            var _crearOperacionRequest = new CrearOperacionDto
            {
                declaracion_causal = request.Monto <= 3000 ? "" : request.DeclaracionCasual,
                cajero = request.IdCajero,
                cantidad = request.Monto,
                tipo_operacion = request.TipoOperacionMaccord,
                token = request.Token
            };
            var _crearOperacionResponse = await _maccordService.CreateOperacionAsync(_crearOperacionRequest);
            var dataRecibo = new ReciboDto
            {
                AgenteMaccorp = request.AgenteMaccorp,
                Cajero = request.IdCajero,
                NroCuentaDePago = request.NroCuentaDePago,
                Monto = request.Monto,
                Telefono = request.Telefono,
                Documento = request.Documento,
                Direccion = request.Direccion,
                IdOperacionMaccorp =_crearOperacionResponse.id_operacion,
                PaisResidencia = request.PaisResidencia,
                NombreApellido = request.NombreApellido
            };

            List<ReciboDto> list = new List<ReciboDto>
            {
                dataRecibo
            };

            var dataSource = new Dictionary<string, object>()
            {
                {"ClienteDts", list},
            };
            var _generarPdfResponse = await _pdfService.GeneratePdfAsync("Recibo", dataSource);
            var _reciboBase64 = System.Convert.ToBase64String(_generarPdfResponse);
            var enviarRecibo = new EnviarReciboDto
            {
                 id_operacion = _crearOperacionResponse.id_operacion,
                 recibo = _reciboBase64,

            };
            await _maccordService.EnviarReciboAsync(enviarRecibo);
            return OkResponse<OperacionDto>.Ok(new OperacionDto { IdOperacion = 0 });
        }
    }
}
