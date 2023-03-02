namespace Exceptions
{
    public class DataException : BaseException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DataException"/> class.
		/// </summary>
		public DataException() : base() {}
		/// <summary>
		/// Initializes a new instance of the <see cref="DataException"/> class.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public DataException(string message) : base(message) {}
		/// <summary>
		/// Initializes a new instance of the <see cref="DataException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner.</param>
		public DataException(string message, System.Exception inner) : base(message, inner) { }
	}//end of class
}//end of namespace
