using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EliteAPI.Journal.Processor.Abstractions;

namespace EliteAPI.Journal.Processor
{
    /// <inheritdoc />
    public class JournalProcessor : IJournalProcessor
    {
        /// <inheritdoc />
        public event EventHandler<string> NewJournalEntry;

        /// <inheritdoc />
        public event EventHandler<(FileInfo, string)> NewSupportEntry;

        public JournalProcessor()
        {
            _cache = new Dictionary<FileInfo, IList<string>>();
        }

        private readonly IDictionary<FileInfo, IList<string>> _cache;

        private readonly FileInfo _activeJournal;

        /// <inheritdoc />
        public Task ProcessJournalFile(FileInfo journalFile)
        {
            IEnumerable<string> journalContent = ReadAllLines(journalFile);
            foreach (string journalEntry in journalContent)
            {
                if (IsInCache(journalFile, journalEntry)) { continue; }

                AddToCache(journalFile, journalEntry);

                NewJournalEntry?.Invoke(this, journalEntry);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task ProcessSupportFiles(IEnumerable<FileInfo> supportFiles)
        {
            foreach (FileInfo supportFile in supportFiles)
            {
                string fileContent = ReadAllText(supportFile);

                if (IsInCache(supportFile, fileContent))
                {
                    continue;
                }

                SetInCache(supportFile, fileContent);

                NewSupportEntry?.Invoke(this, (supportFile, fileContent));
            }

            return Task.CompletedTask;
        }

        private void AddToCache(FileInfo file, string content)
        {
            if (!_cache.ContainsKey(file))
            {
                _cache.Add(file, new List<string>() { content });
            }
            else
            {
                _cache[file].Add(content);
            }
        }

        private void SetInCache(FileInfo file, string content)
        {
            if (!_cache.ContainsKey(file))
            {
                _cache.Add(file, new List<string> { content });
            }
            else
            {
                _cache[file] = new List<string> { content };
            }
        }

        private bool IsInCache(FileInfo file, string content)
        {
            return _cache.ContainsKey(file) && _cache[file].Contains(content);
        }

        private IEnumerable<string> ReadAllLines(FileInfo file)
        {
            using FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.RandomAccess);
            using StreamReader stream = new StreamReader(fs, Encoding.UTF8);

            string line;
            while ((line = stream.ReadLine()) != null)
            {
                yield return line;
            }
        }

        private string ReadAllText(FileInfo file) => string.Join(Environment.NewLine, ReadAllLines(file));
    }
}