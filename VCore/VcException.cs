using System;
using System.Runtime.Serialization;

namespace VCore
{
    public class VcException : Exception
    {
        public VcException() { }
        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public VcException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public VcException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
        public VcException(SerializationInfo serializationInfo, StreamingContext context)
           : base(serializationInfo, context)
        {

        }
    }
}
