namespace Exceptions
{
    /// <summary>
    /// Summary description for RequiredFieldException.
    /// </summary>
    public class RequiredFieldException : DataException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RequiredFieldException"/> class.
		/// </summary>
		public RequiredFieldException()
        {}
		/// <summary>
		/// Initializes a new instance of the <see cref="RequiredFieldException"/> class.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public RequiredFieldException(string message) : base(message) {}
		/// <summary>
		/// Initializes a new instance of the <see cref="RequiredFieldException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner.</param>
		public RequiredFieldException(string message, System.Exception inner) : base(message, inner) { }
	}//end of class
}
