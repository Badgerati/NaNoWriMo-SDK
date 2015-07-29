using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Base
{
    public class WordCountBase
    {

        public long Count { get; private set; }
        public DateTime Date { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordCountBase"/> class.
        /// </summary>
        /// <param name="wordCount">The word count.</param>
        /// <param name="date">The date.</param>
        public WordCountBase(long wordCount, DateTime date)
        {
            Count = wordCount;
            Date = date;
        }

    }
}
