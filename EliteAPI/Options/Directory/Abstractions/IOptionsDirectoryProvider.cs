using System.IO;
using System.Threading.Tasks;

namespace EliteAPI.Options.Directory.Abstractions
{
    /// <summary>
    /// Provides the options directory
    /// </summary>
    public interface IOptionsDirectoryProvider
    {
        /// <summary>
        /// Finds the options directory containing all the option directories
        /// </summary>
        Task<DirectoryInfo> FindOptionsDirectory();
    }
}