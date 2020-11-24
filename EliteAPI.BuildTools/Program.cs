using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace EliteAPI.BuildTools
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args != null)
            {
                string command = args[0].ToLower();
                string argument = string.Join(' ', args.Skip(1));

                switch (command)
                {
                    case "json":
                        string json = await FromJson(argument);
                        Console.WriteLine(json);
                        break;

                    case "sort":
                        await Sort(argument);
                        break;

                    case "test":
                        await Tests();
                        break;
                }
            }
        }

        private static async Task Tests()
        {
            

        }

        private static async Task Sort(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var file in new DirectoryInfo(path).GetFiles())
                {
                    await Sort(file.FullName);
                }
            }

            if (File.Exists(path))
            {
                string version = Regex.Match(await File.ReadAllTextAsync(path), "\"gameversion\":\"(.*?)\"").Groups[1].Value;

                Directory.CreateDirectory($"Journal/{version}");

                string[] entries = await File.ReadAllLinesAsync(path);
                foreach (var entry in entries)
                {
                    try
                    {
                        string file = $"Journal/{version}/{JsonConvert.DeserializeObject<dynamic>(entry).@event}.json";
                        if (!File.Exists(file) || !(await File.ReadAllLinesAsync(file)).Contains(entry))
                        {
                            await File.AppendAllTextAsync(file, entry + Environment.NewLine);
                        }
                    }
                    catch
                    {

                    }
                    
                }
            }
        }

        private static async Task<string> FromJson(string input)
        {
            try
            {
                string eventName = JsonConvert.DeserializeObject<dynamic>(input).@event + "Event";

                input = input.Replace('\u2018', '\'').Replace('\u2019', '\'').Replace('\u201c', '\"')
                    .Replace('\u201d', '\"');
                input = Regex.Replace(input, "(\"event\":.*?,)", string.Empty);
                input = Regex.Replace(input, "(\"timestamp\":.*?,)", string.Empty);

                await File.WriteAllTextAsync("input", input);

                var processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    WorkingDirectory = Directory.GetCurrentDirectory()
                };

                var process = Process.Start(processStartInfo);
                await process.StandardInput.WriteLineAsync(
                    $"quicktype --lang cs --out output input --namespace EliteAPI.Event.Models --array-type list --features complete --top-level {eventName}");
                process.WaitForExit(500);

                Thread.Sleep(500);

                string output = await File.ReadAllTextAsync("output");

                output = Regex.Replace(output, "//.*\n", string.Empty);
                output = Regex.Replace(output, "self, EliteAPI.Event.Models.Converter.Settings", "self");
                output = Regex.Replace(output, "json, EliteAPI.Event.Models.Converter.Settings", "json");
                output = Regex.Replace(output, "public static class Serialize.*\\}", "\n}", RegexOptions.Singleline);
                output = Regex.Replace(output, "public partial class ([^ ]*)\n    {", "$&\n        internal $1() { }\n");
                output = Regex.Replace(output, "internal EventHandler() \\{\\}", string.Empty);
                output = Regex.Replace(output, ";\n\n    public partial class " + eventName, "$& : EventBase");
                output = Regex.Replace(output, "using Newtonsoft.Json.Converters;\n", "$&    using Abstractions;\n\n");
                output = Regex.Replace(output, "set;", "private set;");

                output = Regex.Replace(output, "List", "IReadOnlyList");
                output = Regex.Replace(output, "internal " + eventName + ".*\n(\n        public static)", "$1");

                if (Regex.Matches(output, "public partial class.*?public partial class.*?", RegexOptions.Singleline).Count > 1)
                {
                    output = Regex.Replace(output, "(EventBase\n.*?}\n    )}", "$1", RegexOptions.Singleline);
                    output = Regex.Replace(output, "}\n\n    public partial class " + eventName, "}\n\n$&", RegexOptions.Singleline);

                    var subClasses = Regex.Matches(output, "\\b(\\w+)\\s+\\1\\b").ToList().Select(x => x.Groups[1].Value);
                    foreach (var subClass in subClasses)
                    {
                        output = Regex.Replace(output, $"{subClass} {subClass}", $"{subClass}Info {subClass}");
                        output = Regex.Replace(output, $"public partial class {subClass}", $"public class {subClass}Info");
                        output = Regex.Replace(output, $"internal {subClass}", $"internal {subClass}Info");
                    }
                }

                output += "\nnamespace EliteAPI.Event.Handler\n";
                output += "{\n";
                output += "    using System;\n";
                output += "    using Models;\n\n";
                output += "    public partial class EventHandler\n";
                output += "    {\n";
                output += $"        public event EventHandler<{eventName}> {eventName};\n";
                output +=
                    $"        internal void Invoke{eventName}({eventName} arg) => {eventName}?.Invoke(this, arg);\n";
                output += "    }\n";
                output += "}";

                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return "";
            }
        }
    }
}
