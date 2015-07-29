using NaNoWriMo.SDK.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NaNoWriMo.SDK.Helpers
{
    public static class WebHelper
    {

        /// <summary>
        /// Gets the XML from a web endpoint.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="NanoException"></exception>
        public static XDocument GetXml(string url)
        {
            var request = (WebRequest)HttpWebRequest.Create(url);

            using (var response = request.GetResponse())
            {
                var xml = XDocument.Load(response.GetResponseStream());
                var _error = xml.Descendants("error").SingleOrDefault();

                if (_error != default(XElement))
                {
                    throw new NanoException(_error.Value);
                }

                return xml;
            }
        }

        /// <summary>
        /// Sends the post data to update a word count.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="username">The username.</param>
        /// <param name="wordCount">The word count.</param>
        public static void SendPostData(string url, string hash, string username, long wordCount)
        {
            var request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";

            request.Headers.Add("hash", hash);
            request.Headers.Add("name", username);
            request.Headers.Add("wordcount", wordCount.ToString());

            using (var response = request.GetResponse()) { }
        }

    }
}
