using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response
{
    public class MaccorpResponseDto
    {
        public bool success { get; set; }
        public int status { get; set; }
        public string code { get; set; }
        public string[] errors { get; set; }
    }

    public class MaccorpResponseDto<T>  where T : class
    {
        [JsonProperty("success")]
        public bool success { get; set; }
        [JsonProperty("status")]
        public int status { get; set; }
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("errors")]
        public string[] errors { get; set; }
        [JsonProperty("data")]
        public T data { get; set; }
        
    }
}
