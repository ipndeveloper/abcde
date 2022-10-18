
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Infrastructure.Helpers
{
    public class FileHelper
    {
        public static string AssemblyDirectory
        {
            get
            {
                //string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                //UriBuilder uri = new UriBuilder(codeBase);
                //string path = Uri.UnescapeDataString(uri.Path);
                //return Path.GetDirectoryName(path);
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }
        public static async Task<Stream> ReadFileAsync(string path)
        {
            byte[] result;

            using (FileStream SourceStream = File.Open(path, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
                return new MemoryStream(result);
            }
           

        }
    }
}
