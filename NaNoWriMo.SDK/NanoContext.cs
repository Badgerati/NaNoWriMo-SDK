using NaNoWriMo.SDK.Regions;
using NaNoWriMo.SDK.Sites;
using NaNoWriMo.SDK.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK
{
    public static class NanoContext
    {

        /// <summary>
        /// Returns information about the User specified.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public static User GetUser(string username)
        {
            return new User(username);
        }

        /// <summary>
        /// Returns information about the Site.
        /// </summary>
        /// <returns></returns>
        public static Site GetSite()
        {
            return new Site();
        }

        /// <summary>
        /// Returns a information for the Region Name specified.
        /// </summary>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        public static Region GetRegion(string regionName)
        {
            return new Region(regionName);
        }

    }
}
