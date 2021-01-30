using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EliteAPI.Services.FileReader.Abstractions
{
    /// <summary>
    /// A file reading service
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Reads all the lines of a file
        /// </summary>
        /// <param name="file">The file to be read</param>
        IEnumerable<string> ReadAllLines(FileInfo file);

        /// <summary>
        /// Reads all the text of a file
        /// </summary>
        /// <param name="file">The file to be read</param>
        string ReadAllText(FileInfo file);
    }
}
