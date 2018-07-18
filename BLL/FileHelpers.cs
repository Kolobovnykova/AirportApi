using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace BLL
{
    public static class FileHelpers
    {
        public static async Task WriteTextAsync(List<CrewDTO> data)
        {
            var fileName = "Log_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HH.mm.ss") +
                           ".csv";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            var sb = new StringBuilder();
            foreach (var crew in data)
            {
                sb.AppendLine("Crew added");
                sb.Append($"Id: {crew.Id}, ");
                sb.Append($"Pilot: {crew.Pilot.FirstName}, ");
                sb.Append($"Stewardesses number: {crew.Stewardesses.Count}");
                sb.AppendLine();
            }

            byte[] encodedText = Encoding.Unicode.GetBytes(sb.ToString());

            using (FileStream sourceStream = new FileStream(path,
                FileMode.Append, FileAccess.Write, FileShare.None,
                4096, true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            }
        }
    }
}