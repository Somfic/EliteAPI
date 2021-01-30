using System.IO;
using System.Threading.Tasks;

namespace EliteAPI.Options.Provider.Abstractions
{
    public interface IOptionsProvider
    {
        /// <summary>
        ///     Finds the bindings file from the specified options directory
        /// </summary>
        /// <param name="optionsDirectory">The options directory</param>
        Task<FileInfo> FindBindingsFile(DirectoryInfo optionsDirectory);
    }
}
