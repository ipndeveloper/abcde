using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Contracts.Ports.Services.Reports
{
    public interface IPdfService
    {
        public Task<byte[]> GeneratePdfAsync(string reportName, Dictionary<string, object> data);
    }
}
