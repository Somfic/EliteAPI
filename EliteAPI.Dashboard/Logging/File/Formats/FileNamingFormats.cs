using EliteAPI.Dashboard.Logging.File.Formats.Abstractions;
using EliteAPI.Dashboard.Logging.File.Formats.Default;

namespace EliteAPI.Dashboard.Logging.File.Formats
{
    /// <summary>
    /// Default file naming formats
    /// </summary>
    public static class FileNamingFormats
    {
        /// <summary>
        /// The default file naming format
        /// </summary>
        public static IFileNamingFormat Default => new DefaultFileNamingFormat();
    }
}
