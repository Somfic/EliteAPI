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
}
