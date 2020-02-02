namespace EliteAPI.EDSM
{
    /// <summary>
    /// A parameter for an EDSM API call.
    /// </summary>
    public class EDSMParameter
    {
        /// <summary>
        /// Creates a new EDSM parameter.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        public EDSMParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
        /// <summary>
        /// The name of the parameter.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The value of the parameter.
        /// </summary>
        public object Value { get; private set; }
    }
}