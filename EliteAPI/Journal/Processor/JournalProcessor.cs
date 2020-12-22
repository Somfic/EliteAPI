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
        private readonly IDictionary<FileInfo, IList<string>> _cache;

        public JournalProcessor()
        {
            _cache = new Dictionary<FileInfo, IList<string>>();
        }

        /// <inheritdoc />
        public event EventHandler<JournalEntry> NewJournalEntry;

        /// <inheritdoc />
        public Task ProcessJournalFile(FileInfo journalFile, bool isWhileCatchingUp)
        {
            var journalContent = ReadAllLines(journalFile);
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

        private IEnumerable<string> ReadAllLines(FileInfo file)
        {
            using var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000,
                FileOptions.RandomAccess);
            using var stream = new StreamReader(fs, Encoding.UTF8);

            string line;
            while ((line = stream.ReadLine()) != null) yield return line;
        }

        private string ReadAllText(FileInfo file)
        {
            return string.Join(Environment.NewLine, ReadAllLines(file));
        }
    }
}