using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Exceptions
{
    public class ApplicationLayerException : Exception
    {
        public ApplicationLayerException()
        {
        }

        public ApplicationLayerException(string message) : base(message)
        {
        }

        public ApplicationLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApplicationLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
