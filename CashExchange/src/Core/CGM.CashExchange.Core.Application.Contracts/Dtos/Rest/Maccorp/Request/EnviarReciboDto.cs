using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Request
{
    public class EnviarReciboDto
    {
        public string id_operacion { get; set; }
        public string recibo { get; set; }
    }
}
