using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamoraAlcivarExamenFinal.Services
{
    public class LogService
    {
        private readonly string _logFilePath;

        public LogService()
        {
            string fileName = $"Logs_Zamora.txt";
            _logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
        }

        public async Task RegistrarLog(string entry)
        {
            using StreamWriter writer = new StreamWriter(_logFilePath, append: true);
            await writer.WriteLineAsync(entry);
        }

        public async Task<List<string>> ObtenerLogs()
        {
            if (!File.Exists(_logFilePath))
                return new List<string>();

            return (await File.ReadAllLinesAsync(_logFilePath)).ToList();
        }
    }
}