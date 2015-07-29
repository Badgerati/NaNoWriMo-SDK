using NaNoWriMo.SDK.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Users
{
    public class UserWordCount : WordCountBase
    {

        public string UserID { get; private set; }
        public string Username { get; private set; }
        public bool Winner { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserWordCount"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <param name="wordCount">The word count.</param>
        /// <param name="winner">if set to <c>true</c> [winner].</param>
        public UserWordCount(string userId, string username, long wordCount, bool winner)
            : base(wordCount, DateTime.Now)
        {
            UserID = userId;
            Username = username;
            Winner = winner;
        }

    }
}
