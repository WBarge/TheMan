namespace Exceptions
{
    public class WarningException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WarningException"/> class.
        /// </summary>
        public WarningException()
        {}
        /// <summary>
        /// Initializes a new instance of the <see cref="WarningException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public WarningException(string message) : base(message) {}
        /// <summary>
        /// Initializes a new instance of the <see cref="WarningException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public WarningException(string message, System.Exception inner) : base(message, inner) {}
    }
}
