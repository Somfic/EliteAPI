using System.IO;
using System.Threading.Tasks;

namespace EliteAPI.Journal.Provider.Abstractions
{
    /// <summary>
    /// Finds the journal and support files
    /// </summary>
    public interface IJournalProvider
    {
        /// <summary>
        /// Finds the active journal file from the specified journal directory
        /// </summary>
        /// <param name="journalDirectory"> The journal directory </param>
        Task<FileInfo> FindJournalFile(DirectoryInfo journalDirectory);
    }
}