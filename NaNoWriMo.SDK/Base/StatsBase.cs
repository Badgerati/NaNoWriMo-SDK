using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Base
{
    public class StatsBase : WordCountBase
    {

        public long Min { get; private set; }
        public long Max { get; private set; }
        public double Average { get; private set; }
        public double StdDev { get; private set; }
        public long UserCount { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatsBase"/> class.
        /// </summary>
        /// <param name="wordCount">The word count.</param>
        /// <param name="date">The date.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="avg">The average.</param>
        /// <param name="stdDev">The standard dev.</param>
        /// <param name="count">The count.</param>
        public StatsBase(long wordCount, DateTime date, long min, long max, double avg, double stdDev, long count)
            : base(wordCount, date)
        {
            Min = min;
            Max = max;
            Average = avg;
            StdDev = stdDev;
            UserCount = count;
        }

    }
}
