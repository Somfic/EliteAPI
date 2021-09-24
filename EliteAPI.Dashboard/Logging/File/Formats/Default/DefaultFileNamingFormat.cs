using System.IO;
using EliteAPI.Dashboard.Logging.File.Formats.Abstractions;

namespace EliteAPI.Dashboard.Logging.File.Formats.Default
{
    public class DefaultFileNamingFormat : IFileNamingFormat
    {
        internal DefaultFileNamingFormat()
        {

        }

        /// <inheritdoc />
        public string NameFile(DirectoryInfo directory, string name)
        {
            int i = 0;

            while (true)
            {
                i++;

                string file = $"{name}.{i:000}.log";

                if (directory.GetFiles(file).Length == 0)
                {
                    return file;
                }
            }
        }
    }
}
