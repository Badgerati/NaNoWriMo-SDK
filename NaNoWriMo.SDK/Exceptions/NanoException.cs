using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaNoWriMo.SDK.Exceptions
{
    public class NanoException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="NanoException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NanoException(string message)
            : base(message)
        {

        }

    }
}
