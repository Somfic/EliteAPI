using System.IO;
using System.Threading.Tasks;

namespace EliteAPI.Journal.Directory.Abstractions
{
    /// <summary>
    ///     Provides the journal directory
    /// </summary>
    public interface IJournalDirectoryProvider
    {
        /// <summary>
        ///     Finds the journal directory containing all the journal and support files
        /// </summary>
        Task<DirectoryInfo> FindJournalDirectory();
    }
}