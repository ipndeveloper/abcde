using CGM.CashExchange.Core.Application.Contracts.Ports.Services.Reports;
using CGM.CashExchange.Infrastructure.Helpers;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Infrastructure.Adapters.Services.Reports
{
    public class RdlcService : IPdfService
    {
        public async Task<byte[]> GeneratePdfAsync(string reportName, Dictionary<string, object> data)
        {
           
                var fileDirPath = FileHelper.AssemblyDirectory;
                string rdlcFilePath = string.Format("{0}\\Adapters\\Services\\Reports\\Rdlc\\{1}.rdlc", fileDirPath, reportName);
                var fileStream = await FileHelper.ReadFileAsync(rdlcFilePath);
                using (LocalReport report = new())
                {
                    report.LoadReportDefinition(fileStream);

                    foreach (var record in data)
                    {
                        report.DataSources.Add(new ReportDataSource(record.Key, record.Value));

                    }

                    return report.Render("PDF");

                }

           
           

        }
    }
}
