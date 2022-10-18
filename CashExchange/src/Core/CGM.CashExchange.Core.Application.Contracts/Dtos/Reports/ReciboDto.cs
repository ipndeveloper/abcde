using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Contracts.Dtos.Reports
{
    public class ReciboDto
    {
        public decimal Monto { get; set; }
        public int Cajero { get; set; }

        public string NombreApellido { get; set; }

        public string Documento { get; set; }

        public string Direccion { get; set; }

        public string PaisResidencia { get; set; }
        public string Telefono { get; set; }

        public string IdOperacionMaccorp { get; set; }

        public string AgenteMaccorp { get; set; }


        public string NroCuentaDePago { get; set; }


    }
}
