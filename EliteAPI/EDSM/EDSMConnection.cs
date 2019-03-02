using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace EliteAPI.EDSM
{
    public class EDSMConnection
    {
        public string Execute(string url, List<Tuple<string, string>> Parameters)
        {
            //Convert the list to a HTML query.
            List<Tuple<string, string>> parameters = new List<Tuple<string, string>>();
            List<string> parametersLocalised = new List<string>();
            parameters.ForEach(x => parametersLocalised.Add($"{x.Item1}={x.Item2}"));
            string html = $"{url}?{string.Join("&", parametersLocalised)}";

            Console.WriteLine(parameters.Count);
            Console.WriteLine(html);

            //Peform the GET request.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
