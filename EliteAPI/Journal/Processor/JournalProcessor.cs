using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EliteAPI.Journal.Processor.Abstractions;
using EliteAPI.Services.FileReader.Abstractions;

namespace EliteAPI.Journal.Processor
{
    /// <inheritdoc />
    public class JournalProcessor : IJournalProcessor
    {
        private readonly IFileReader _fileReader;
        private readonly IDictionary<FileInfo, IList<string>> _cache;

        public JournalProcessor(IFileReader fileReader)
        {
            _fileReader = fileReader;
            _cache = new Dictionary<FileInfo, IList<string>>();
        }

        /// <inheritdoc />
        public event EventHandler<JournalEntry> NewJournalEntry;

        /// <inheritdoc />
        public Task ProcessJournalFile(FileInfo journalFile, bool isWhileCatchingUp)
        {
            var journalContent = _fileReader.ReadAllLines(journalFile);
            foreach (var entry in journalContent)
            {
                if (IsInCache(journalFile, entry)) continue;

                AddToCache(journalFile, entry);

                NewJournalEntry?.Invoke(this, new JournalEntry(entry, isWhileCatchingUp));
            }

            return Task.CompletedTask;
        }

        private void AddToCache(FileInfo file, string content)
        {
            if (!_cache.ContainsKey(file))
                _cache.Add(file, new List<string> {content});
            else
                _cache[file].Add(content);
        }

        private bool IsInCache(FileInfo file, string content)
        {
            return _cache.ContainsKey(file) && _cache[file].Contains(content);
        }
    }
}