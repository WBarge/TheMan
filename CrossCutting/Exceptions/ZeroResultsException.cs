namespace Exceptions
{
    /// <summary>
    /// Summary description for ZeroResultsException.
    /// </summary>
    public class ZeroResultsException : DataException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ZeroResultsException"/> class.
		/// </summary>
		public ZeroResultsException()
        {}
		/// <summary>
		/// Initializes a new instance of the <see cref="ZeroResultsException"/> class.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public ZeroResultsException(string message) : base(message) {}
		/// <summary>
		/// Initializes a new instance of the <see cref="ZeroResultsException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner.</param>
		public ZeroResultsException(string message, System.Exception inner) : base(message, inner) { }
	}//end of class
}//end of namespace
