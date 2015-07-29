using NaNoWriMo.SDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Regions
{
    public class Region
    {

        public string RegionName { get; private set; }
        public long NumberOfParticipants { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public RegionalWordCount WordCount { get; private set; }
        public IList<RegionalWordCountEntry> History { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        /// <param name="regionName">Name of the region.</param>
        /// <param name="initialise">if set to <c>true</c> [initialise].</param>
        public Region(string regionName, bool initialise = true)
        {
            RegionName = regionName;

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
            var xml = WebHelper.GetXml(NanoURL.REGIONAL_WORDCOUNT + RegionName);

            WordCount = new RegionalWordCount(
                xml.Descendants("rid").Single().Value,
                xml.Descendants("rname").Single().Value,
                Convert.ToInt64(xml.Descendants("region_wordcount").Single().Value),
                Convert.ToInt64(xml.Descendants("min").Single().Value),
                Convert.ToInt64(xml.Descendants("max").Single().Value),
                Convert.ToDouble(xml.Descendants("average").Single().Value),
                Convert.ToDouble(xml.Descendants("stddev").Single().Value),
                Convert.ToInt64(xml.Descendants("count").Single().Value),
                Convert.ToDouble(xml.Descendants("donations").Single().Value),
                Convert.ToInt64(xml.Descendants("numdonors").Single().Value));

            NumberOfParticipants = Convert.ToInt64(xml.Descendants("numparticipants").Single().Value);

            xml = WebHelper.GetXml(NanoURL.REGIONAL_WORDCOUNT_HISTORY + RegionName);

            var entries = xml.Descendants("wordcounts").Single().Descendants("wcentry");
            History = new List<RegionalWordCountEntry>(entries.Count());

            foreach (var entry in entries)
            {
                History.Add(new RegionalWordCountEntry(
                    Convert.ToInt64(xml.Descendants("wc").Single().Value),
                    Convert.ToDateTime(xml.Descendants("wcdate").Single().Value),
                    Convert.ToInt64(xml.Descendants("min").Single().Value),
                    Convert.ToInt64(xml.Descendants("max").Single().Value),
                    Convert.ToDouble(xml.Descendants("average").Single().Value),
                    Convert.ToDouble(xml.Descendants("stddev").Single().Value),
                    Convert.ToInt64(xml.Descendants("count").Single().Value),
                    Convert.ToDouble(xml.Descendants("donations").Single().Value),
                    Convert.ToInt64(xml.Descendants("numdonors").Single().Value)));
            }

            LastUpdated = DateTime.Now;
        }

    }
}
