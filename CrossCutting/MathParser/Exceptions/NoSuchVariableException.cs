using System;
using System.Runtime.Serialization;

namespace MathParser.Exceptions
{
    [Serializable]
    public class NoSuchVariableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchVariableException"/> class.
        /// </summary>
        public NoSuchVariableException() : base(StringResources.Undefined_Variable){}

        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchVariableException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NoSuchVariableException(string message) : base(message){}

        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchVariableException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public NoSuchVariableException(string message, Exception innerException) : base(message, innerException){}

        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchVariableException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected NoSuchVariableException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}
