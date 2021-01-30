namespace EliteAPI.Journal.Processor.Abstractions
{
    /// <summary>
    /// A journal entry
    /// </summary>
    public class JournalEntry
    {
        public JournalEntry(string json, bool isWhileCatchingUp)
        {
            Json = json;
            IsWhileCatchingUp = isWhileCatchingUp;
        }

        /// <summary>
        /// This entry's Json event
        /// </summary>
        public string Json { get; }

        /// <summary>
        /// Whether this entry was ran before EliteAPI was started
        /// </summary>
        public bool IsWhileCatchingUp { get; }
    }
}