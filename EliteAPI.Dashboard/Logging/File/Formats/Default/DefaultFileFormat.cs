using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EliteAPI.Dashboard.Logging.File.Formats.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Dashboard.Logging.File.Formats.Default
{
    public class DefaultFileFormat : IFileFormat
    {
        internal DefaultFileFormat()
        {

        }

        /// <inheritdoc />
        public StringBuilder CreateLogEntry(LogLevel logLevel, string category, EventId eventId, string message, Exception ex)
        {
            StringBuilder entry = new StringBuilder();

            var now = DateTime.Now;

            // 2021/01/23 24:12:23.400
            entry.Append($"{now.ToString("yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} ");

            // debug
            entry.Append($"{logLevel.ToString().ToLower(),5} ");

            // Somfic.Logging.Test.Source
            entry.Append($"{category} ");

            entry.Append(message);

            if (ex != null)
            {
                string stack = ex.StackTrace;

                while (ex != null)
                {
                    entry.AppendLine();

                    // Invalid file format
                    entry.Append(GetPrettyExceptionName(ex));

                    entry.Append(": ");
                    entry.Append(ex.Message.Trim());

                    if (ex.Data.Count > 0)
                    {
                        entry.AppendLine();
                        entry.Append(JsonConvert.SerializeObject(ex.Data));
                    }

                    ex = ex.InnerException;
                }

                if (!string.IsNullOrWhiteSpace(stack))
                {
                    IEnumerable<string> stackLines = stack.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    stackLines = stackLines.Reverse();

                    for (int index = 0; index < stackLines.Count(); index++)
                    {
                        string stackLine = stackLines.ElementAt(index).Trim();

                        entry.AppendLine();
                        entry.Append(index + 1);
                        entry.Append($": {stackLine}");
                    }
                }
            }

            return entry;
        }

        private string GetPrettyExceptionName(Exception ex)
        {
            string output = Regex.Replace(ex.GetType().Name, @"\p{Lu}", m => " " + m.Value.ToLowerInvariant());

            output = ex.GetType().Name == "Exception" ? "Exception" : output.Replace("exception", "");

            output = output.Trim();
            output = char.ToUpperInvariant(output[0]) + output.Substring(1);
            switch (output)
            {
                case "I o":
                    output = "IO";
                    break;
                case "My sql":
                    output = "MySQL";
                    break;
                case "Sql":
                    output = "SQL";
                    break;
            }

            return output;
        }
    } 
}
