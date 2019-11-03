using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
namespace EliteAPI.EDSM
{
    public class EDSMConnection
    {
        /// <summary>
        /// Executes an EDSM API request.
        /// </summary>
        /// <param name="entry">The entry to process.</param>
        /// <returns></returns>
        public string Execute(EDSMEntry entry) => Execute(entry.Url, entry.Parameters);
        private string Execute(string url, List<EDSMParameter> Parameters)
        {
            string html = "";
            string returnHtml = "";
            //Convert the list to a HTML query.
            List<string> parametersLocalised = new List<string>();
            Parameters.ForEach(x => parametersLocalised.Add($"{x.Name}={x.Value.ToString()}"));
            html = $"{url}?{string.Join("&", parametersLocalised)}";
            //Preform the GET request.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(html);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                returnHtml = reader.ReadToEnd();
            }
            return returnHtml;
        }
    }
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
