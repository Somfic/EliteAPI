using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.Journal.Directory
{
    /// <summary>
    /// Finds the journal directory
    /// </summary>
    public interface IJournalDirectoryProvider
    {
        /// <summary>
        /// Finds the journal directory containing all the journal and support files
        /// </summary>
        Task<DirectoryInfo> FindJournalDirectory();
    }
}
