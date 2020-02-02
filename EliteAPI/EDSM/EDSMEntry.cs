using System.Collections.Generic;

namespace EliteAPI.EDSM
{
    /// <summary>
    /// An entry for the EDSM API.
    /// </summary>
    public class EDSMEntry
    {
        /// <summary>
        /// Creates a new EDSM API entry.
        /// </summary>
        /// <param name="url">The base URL for the API call.</param>
        /// <param name="parameter">The parameters for the API call.</param>
        public EDSMEntry(string url, EDSMParameter parameter)
        {
            Url = url;
            Parameters = new List<EDSMParameter> { parameter };
        }
        /// <summary>
        /// Creates a new EDSM API entry.
        /// </summary>
        /// <param name="url">The base URL for the API call.</param>
        /// <param name="parameters">A list of parameters for the API call.</param>
        public EDSMEntry(string url, List<EDSMParameter> parameters)
        {
            Url = url;
            Parameters = parameters;
        }
        void AddParameter(EDSMParameter parameter) => Parameters.Add(parameter);
        void RemoveParameter(EDSMParameter parameter) => Parameters.Remove(parameter);
        /// <summary>
        /// The base URL of the API call.
        /// </summary>
        public string Url { get; private set; }
        /// <summary>
        /// The list of parameters for the API call.
        /// </summary>
        public List<EDSMParameter> Parameters { get; private set; }
    }
}