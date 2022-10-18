using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Request
{
    public class CrearOperacionDto 
    {
        [JsonProperty("token")]
        public string  token { get; set; }
        [JsonProperty("tipo_operacion")]
        public string   tipo_operacion { get; set; }
        [JsonProperty("declaracion_causal")]
        public string   declaracion_causal { get; set; }
        [JsonProperty("cantidad")]

        public decimal  cantidad { get; set; }
        [JsonProperty("cajero")]
        public int  cajero { get; set; } 
    }
}
