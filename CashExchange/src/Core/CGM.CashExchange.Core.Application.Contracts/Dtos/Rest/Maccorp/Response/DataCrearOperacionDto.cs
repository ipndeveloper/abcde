using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response
{
    public class DataCrearOperacionDto
    {
        [JsonProperty("id_operacion")]
        public string id_operacion { get; set; }

    }
}
