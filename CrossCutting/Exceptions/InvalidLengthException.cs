namespace Exceptions
{
    /// <summary>
    /// Summary description for PhoneTypeException.
    /// </summary>
    public class InvalidLengthException : DataException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidLengthException"/> class.
		/// </summary>
		public InvalidLengthException()
        {}
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidLengthException"/> class.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public InvalidLengthException(string message) : base(message) {}
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidLengthException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner.</param>
		public InvalidLengthException(string message, System.Exception inner) : base(message, inner) { }
	}//end of class
}//end of namespace
