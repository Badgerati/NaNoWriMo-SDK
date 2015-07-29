using NaNoWriMo.SDK.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Sites
{
    public class SiteWordCountEntry : StatsBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteWordCountEntry"/> class.
        /// </summary>
        /// <param name="wordCount">The word count.</param>
        /// <param name="date">The date.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="avg">The average.</param>
        /// <param name="stdDev">The standard dev.</param>
        /// <param name="count">The count.</param>
        public SiteWordCountEntry(long wordCount, DateTime date, long min, long max, double avg, double stdDev, long count)
            : base(wordCount, date, min, max, avg, stdDev, count)
        {
        }

    }
}
