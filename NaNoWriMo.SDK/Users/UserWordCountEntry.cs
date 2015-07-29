using NaNoWriMo.SDK.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Users
{
    public class UserWordCountEntry : WordCountBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserWordCountEntry"/> class.
        /// </summary>
        /// <param name="wordCount">The word count.</param>
        /// <param name="date">The date.</param>
        public UserWordCountEntry(long wordCount, DateTime date)
            : base(wordCount, date)
        {
        }

    }
}
