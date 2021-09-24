using System.IO;

namespace EliteAPI.Dashboard.Logging.File.Formats.Abstractions
{
    /// <summary>
    /// A format used for naming the file
    /// </summary>
    public interface IFileNamingFormat
    {
        string NameFile(DirectoryInfo directory, string name);
    }
}
