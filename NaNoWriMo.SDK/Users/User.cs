using NaNoWriMo.SDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Users
{
    public class User
    {

        public string Username { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public UserWordCount WordCount { get; private set; }
        public IList<UserWordCountEntry> History { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="initialise">if set to <c>true</c> [initialise].</param>
        public User(string username, bool initialise = true)
        {
            Username = username;

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
            var xml = WebHelper.GetXml(NanoURL.USER_WORDCOUNT + Username);

            WordCount = new UserWordCount(
                xml.Descendants("uid").Single().Value,
                xml.Descendants("uname").Single().Value,
                Convert.ToInt64(xml.Descendants("user_wordcount").Single().Value),
                Convert.ToBoolean(xml.Descendants("winner").Single().Value));

            xml = WebHelper.GetXml(NanoURL.USER_WORDCOUNT_HISTORY + Username);

            var entries = xml.Descendants("wordcounts").Single().Descendants("wcentry");
            History = new List<UserWordCountEntry>(entries.Count());

            foreach (var entry in entries)
            {
                History.Add(new UserWordCountEntry(
                    Convert.ToInt64(entry.Descendants("wc").Single().Value),
                    Convert.ToDateTime(entry.Descendants("wcdate").Single().Value)));
            }

            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Updates the User's word count.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        /// <param name="count">The count.</param>
        /// <param name="reInitialise">if set to <c>true</c> [re initialise].</param>
        public void UpdateCount(string secretKey, long count, bool reInitialise = true)
        {
            var key = secretKey + Username + count;
            var bytes = Encoding.UTF8.GetBytes(key);
            var encKey = string.Empty;

            using (var sha = new SHA1Managed())
            {
                var encBytes = sha.ComputeHash(bytes);
                encKey = Convert.ToBase64String(encBytes);
            }

            WebHelper.SendPostData(NanoURL.USER_UPDATE_WORDCOUNT, encKey, Username, count);

            if (reInitialise)
            {
                Initialise();
            }
        }

    }
}
