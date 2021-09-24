using System.IO;
using EliteAPI.Dashboard.Logging.File.Formats;
using EliteAPI.Dashboard.Logging.File.Formats.Abstractions;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Dashboard.Logging.File
{
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// Adds a <see cref="FileLogger"/> instance to the <seealso cref="ILoggingBuilder"/>
        /// </summary>
        /// <param name="name">The name of this log file</param>
        /// <param name="directory">The directory of the log file</param>
        /// <param name="namingFormat">The naming format applied</param>
        /// <param name="format">The format applied</param>
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string name, string directory, IFileNamingFormat namingFormat = null, IFileFormat format = null)
        {
            namingFormat ??= FileNamingFormats.Default;
            format ??= FileFormats.Default;
            
            var dir = new DirectoryInfo(directory);
            Directory.CreateDirectory(dir.FullName);
            var path = Path.Combine(dir.FullName, namingFormat.NameFile(dir, name));

            builder.AddProvider(new FileLoggerProvider(name, path, namingFormat, format));



            return builder;
        }
    }
}