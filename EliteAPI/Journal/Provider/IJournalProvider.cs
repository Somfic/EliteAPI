using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EliteAPI.Journal.Provider
{
    /// <summary>
    /// Finds the journal and support files
    /// </summary>
    public interface IJournalProvider
    {
        /// <summary>
        /// Finds the active journal file from the specified journal directory
        /// </summary>
        /// <param name="journalDirectory">The journal directory</param>
        Task<FileInfo> FindJournalFile(DirectoryInfo journalDirectory);

        /// <summary>
        /// Finds the status.json file from the specified journal directory
        /// </summary>
        /// <param name="journalDirectory">The journal directory</param>
        Task<FileInfo> FindStatusFile(DirectoryInfo journalDirectory);

        /// <summary>
        /// Finds the support files from the specified journal directory
        /// </summary>
        /// <remarks>These are the Shipyard.json, Outfitting.json and Market.json files</remarks>
        /// <param name="journalDirectory">The journal directory</param>
        Task<IEnumerable<FileInfo>> FindSupportFiles(DirectoryInfo journalDirectory);
    }
}
