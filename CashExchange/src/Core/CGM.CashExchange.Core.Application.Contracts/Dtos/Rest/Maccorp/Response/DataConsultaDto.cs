using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response
{
    public class DataConsultaDto
    {
        [JsonProperty("user")]
        public  UserDto user { get; set; }
       

    }
}
