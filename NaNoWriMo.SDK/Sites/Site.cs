using NaNoWriMo.SDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Sites
{
    public class Site
    {

        public long NumberOfParticipants { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public SiteWordCount WordCount { get; private set; }
        public IList<SiteWordCountEntry> History { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Site"/> class.
        /// </summary>
        /// <param name="initialise">if set to <c>true</c> [initialise].</param>
        public Site(bool initialise = true)
        {
            if (initialise)
            {
                Initialise();
            }
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        public void Initialise()
        {
            var xml = WebHelper.GetXml(NanoURL.SITE_WORDCOUNT);

            WordCount = new SiteWordCount(
                Convert.ToInt64(xml.Descendants("site_wordcount").Single().Value),
                Convert.ToInt64(xml.Descendants("min").Single().Value),
                Convert.ToInt64(xml.Descendants("max").Single().Value),
                Convert.ToDouble(xml.Descendants("average").Single().Value),
                Convert.ToDouble(xml.Descendants("stddev").Single().Value),
                Convert.ToInt64(xml.Descendants("count").Single().Value));

            xml = WebHelper.GetXml(NanoURL.SITE_WORDCOUNT_HISTORY);

            NumberOfParticipants = Convert.ToInt64(xml.Descendants("numparticipants").Single().Value);

            var entries = xml.Descendants("wordcounts").Single().Descendants("wcentry");
            History = new List<SiteWordCountEntry>(entries.Count());

            foreach (var entry in entries)
            {
                History.Add(new SiteWordCountEntry(
                    Convert.ToInt64(StripZero(entry.Descendants("wc").Single().Value)),
                    Convert.ToDateTime(entry.Descendants("wcdate").Single().Value),
                    Convert.ToInt64(entry.Descendants("min").Single().Value),
                    Convert.ToInt64(entry.Descendants("max").Single().Value),
                    Convert.ToDouble(entry.Descendants("average").Single().Value),
                    Convert.ToDouble(entry.Descendants("stddev").Single().Value),
                    Convert.ToInt64(StripZero(entry.Descendants("count").Single().Value))));
            }

            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Strips a trailing zero from the end of a string.
        /// (Done because for some reason NaNoWriMo have int's and double's)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private string StripZero(string value)
        {
            return value.Replace(".0", string.Empty);
        }
    }
}
