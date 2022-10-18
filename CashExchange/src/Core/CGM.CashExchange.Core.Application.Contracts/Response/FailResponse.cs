using System;
using System.Collections.Generic;
using System.Text;

namespace CGM.CashExchange.Core.Application.Contracts.Response
{
    public class FailResponse : Response
    {
        public object Error { get; protected set; }
        public string Title { get; set; }

        public string Type { get; set; }
        public FailResponse() { }
        public FailResponse(object error)
        {
            this.Error = error;
        }
        public static  FailResponse Fail(object error , int status , string title = "" , string type = "")
        {
            var result = new FailResponse {Success = false, Error = error, Status = status , Title = title , Type = type };
            return result;
        }
     
    
    }
}
