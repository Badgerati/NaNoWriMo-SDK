using NaNoWriMo.SDK.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Regions
{
    public class RegionalWordCountEntry : StatsBase
    {

        public double Donations { get; private set; }
        public long NumberOfDonors { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionalWordCountEntry"/> class.
        /// </summary>
        /// <param name="wordCount">The word count.</param>
        /// <param name="date">The date.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="avg">The average.</param>
        /// <param name="stdDev">The standard dev.</param>
        /// <param name="count">The count.</param>
        /// <param name="donations">The donations.</param>
        /// <param name="noOfDonors">The no of donors.</param>
        public RegionalWordCountEntry(long wordCount, DateTime date, long min, long max, double avg,
            double stdDev, long count, double donations, long noOfDonors)
            : base(wordCount, date, min, max, avg, stdDev, count)
        {
            Donations = donations;
            NumberOfDonors = noOfDonors;
        }

    }
}
