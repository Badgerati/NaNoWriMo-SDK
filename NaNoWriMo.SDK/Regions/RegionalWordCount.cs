using NaNoWriMo.SDK.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Regions
{
    public class RegionalWordCount : StatsBase
    {

        public string RegionID { get; private set; }
        public string RegionName { get; private set; }
        public double Donations { get; private set; }
        public long NumberOfDonors { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionalWordCount"/> class.
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <param name="wordCount">The word count.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="avg">The average.</param>
        /// <param name="stdDev">The standard dev.</param>
        /// <param name="count">The count.</param>
        /// <param name="donations">The donations.</param>
        /// <param name="noOfDonors">The no of donors.</param>
        public RegionalWordCount(string regionId, string regionName, long wordCount, long min, long max,
            double avg, double stdDev, long count, double donations, long noOfDonors)
            : base(wordCount, DateTime.Now, min, max, avg, stdDev, count)
        {
            RegionID = regionId;
            RegionName = regionName;
            Donations = donations;
            NumberOfDonors = noOfDonors;
        }

    }
}
