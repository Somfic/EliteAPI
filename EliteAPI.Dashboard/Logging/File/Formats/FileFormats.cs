using EliteAPI.Dashboard.Logging.File.Formats.Abstractions;
using EliteAPI.Dashboard.Logging.File.Formats.Default;

namespace EliteAPI.Dashboard.Logging.File.Formats
{
    /// <summary>
    /// Default file formats
    /// </summary>
    public static class FileFormats
    {
        /// <summary>
        /// The default file format
        /// </summary>
        public static IFileFormat Default => new DefaultFileFormat();
    }
}
