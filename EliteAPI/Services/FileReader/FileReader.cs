using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EliteAPI.Services.FileReader.Abstractions;

namespace EliteAPI.Services.FileReader
{
    /// <inheritdoc />
    public class FileReader : IFileReader
    {
        /// <inheritdoc />
        public IEnumerable<string> ReadAllLines(FileInfo file)
        {
            using var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000,
                FileOptions.RandomAccess);
            using var stream = new StreamReader(fs, Encoding.UTF8);

            string line;
            while ((line = stream.ReadLine()) != null) yield return line;
        }

        /// <inheritdoc />
        public string ReadAllText(FileInfo file)
        {
            return string.Join(Environment.NewLine, ReadAllLines(file));
        }
    }
}
