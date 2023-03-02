namespace Exceptions
{
    /// <summary>
    /// Summary description for InvalidParameterException.
    /// </summary>
    public class InvalidParameterException : DataException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidParameterException"/> class.
		/// </summary>
		public InvalidParameterException() : base() {}
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidParameterException"/> class.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public InvalidParameterException(string message) : base(message) {}
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidParameterException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner.</param>
		public InvalidParameterException(string message, System.Exception inner) : base(message, inner) { }
	}//end of class
}//end of namespace
