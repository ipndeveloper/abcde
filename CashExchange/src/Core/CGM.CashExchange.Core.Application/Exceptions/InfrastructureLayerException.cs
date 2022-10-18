using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Exceptions
{
    public class InfrastructureLayerException : Exception
    {
        public InfrastructureLayerException()
        {
        }

        public InfrastructureLayerException(string message) : base(message)
        {
        }

        public InfrastructureLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InfrastructureLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
