using System;

namespace VCore
{
    public class VcInitializationException : VcException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public VcInitializationException()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public VcInitializationException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public VcInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
