namespace Exceptions
{
    /// <summary>
    /// Summary description for Class Dependency.
    /// </summary>
    public class ClassDependencyException : BaseException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassDependencyException"/> class.
		/// </summary>
		public ClassDependencyException()
        {}
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassDependencyException"/> class.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public ClassDependencyException(string message) : base(message) {}
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassDependencyException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner.</param>
		public ClassDependencyException(string message, System.Exception inner) : base(message, inner) {}
	}//end of class
}//end of namespace
