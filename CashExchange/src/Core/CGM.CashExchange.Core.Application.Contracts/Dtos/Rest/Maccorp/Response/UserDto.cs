using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Contracts.Dtos.Rest.Maccorp.Response
{
    public class UserDto
    {
        [JsonProperty("token")]
        public string token { get; set; }
        [JsonProperty("nombre_apellidos")]
        public string nombre_apellidos { get; set; }
        [JsonProperty("fecha_nacimiento")]
        public string fecha_nacimiento { get; set; }
        [JsonProperty("profesion")]
        public string profesion { get; set; }
        [JsonProperty("tipo_documento")]
        public string tipo_documento { get; set; }
        [JsonProperty("n_documento")]
        public string n_documento { get; set; }
        [JsonProperty("fecha_caducidad")]
        public string fecha_caducidad { get; set; }
        [JsonProperty("nacionalidad")]
        public string nacionalidad { get; set; }
        [JsonProperty("residente")]
        public string residente { get; set; }
        [JsonProperty("direccion_residencia")]
        public string direccion_residencia { get; set; }
        [JsonProperty("localidad_residencia")]
        public string localidad_residencia { get; set; }
        [JsonProperty("código_postal")]
        public string codigo_postal { get; set; }
        [JsonProperty("direccion_temporal")]
        public string direccion_temporal { get; set; }
        [JsonProperty("localidad_temporal")]
        public string localidad_temporal { get; set; } 
    }
}
