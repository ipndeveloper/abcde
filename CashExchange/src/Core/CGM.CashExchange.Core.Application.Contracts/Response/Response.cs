using System;
using System.Collections.Generic;
using System.Text;

namespace CGM.CashExchange.Core.Application.Contracts.Response
{
    public class Response
    {
        public bool Success { get;  set; }

        public int Status { get;  set; }

        public string Code { get; set; }

    }
}
