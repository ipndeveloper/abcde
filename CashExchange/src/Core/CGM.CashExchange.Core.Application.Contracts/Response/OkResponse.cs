using System;
using System.Collections.Generic;
using System.Text;

namespace CGM.CashExchange.Core.Application.Contracts.Response
{
    public class OkResponse<T> : Response
    {
        public T Data { get; protected set; }
        public OkResponse() { }
        public OkResponse(T data)
        {
            Data = data;
        }
        public static OkResponse<T> Ok(T data)
        {
            var result = new OkResponse<T> { Data = data, Success = true , Status = 200};
            return result;
        }
    }
}
