using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Utilites
{
	/// <summary>
	/// simple class to hold an error message
	/// also contains utility methods to help build error messages
	/// </summary>
	public class ErrorMessage
	{
		#region Constants
		#endregion Constants

		#region Local Vars
		#endregion Local Vars

		#region Properties

		/// <summary>
		/// The error message
		/// </summary>
		public string Message { get; set; }

		#endregion Properties

		#region Constructors

		/// <summary>
		/// Default contructor will set the message to string.Empty
		/// </summary>
		public ErrorMessage()
		{
			try
			{
				CommonInit();
			}
			catch (Exception x) { Debug.WriteLine(x.Message); }
		}//end of constructor

		/// <summary>
		/// will initialize the message with the passed in string
		/// </summary>
		/// <param name="msg">the message to init the class with</param>
		public ErrorMessage(string msg) : this()
		{
			try
			{
				Message = msg;
			}
			catch (Exception x) { Debug.WriteLine(x.Message); }
	
		}

		public ErrorMessage(Exception exception) : this()
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("Fatel Error!: ");
				sb.Append(exception.Message);
				sb.Append(Environment.NewLine);
				sb.Append("Object: ");
				sb.Append(exception.Source);
				sb.Append(Environment.NewLine);
				sb.Append("Method: ");
				sb.Append(exception.TargetSite);
				sb.Append(Environment.NewLine);
				sb.Append("Stack Trace: ");
				sb.Append(Environment.NewLine);
				sb.Append(exception.StackTrace);
				Message = sb.ToString();
			}
			catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
		}


		#endregion Constructors

		#region Methods

		#region Public Methods

		/// <summary>
		/// Builds an error message
		///     Message will be the start of the message then a list of the errors
		/// </summary>
		/// <example>
		/// <code>ErrorMessage.BuildErrorMessage("The following error(s) were found:" ,errors);</code> 
		/// Will produce assuming errors contains the strings error1 and error2
		/// 
		///         The following error(s) were found:
		///             error1
		///             error2
		///             
		/// </example>
		/// <param name="startOfMessage">the text for the begging </param>
		/// <param name="errors">the errors</param>
		/// <returns></returns>
		public static string BuildErrorMessage(string startOfMessage, IEnumerable<string> errors)
		{
			string errorMsg = startOfMessage + Environment.NewLine;
			try
			{
				foreach (string error in errors)
				{
					errorMsg += "\t" + error + Environment.NewLine;
				}
			}
			catch (Exception x) { Debug.WriteLine(x.Message); }
			return errorMsg;
		}

		/// <summary>
		/// writes the error message to the debug window
		/// will only write if compiled in debug mode
		/// </summary>
		/// <param name="em">The em.</param>
		public static void WriteToDebugWindow(ErrorMessage em)
		{
			WriteToDebugWindow(em.Message);
		}

		/// <summary>
		/// writes a message to the debug window
		/// will only write if compiled in debug mode
		/// </summary>
		/// <param name="str">the message to send to the debug window</param>
		public static void WriteToDebugWindow(string str)
		{
			#if DEBUG
			Debug.WriteLine(str);
			#endif
		}

		public void WriteToDebugWindow()
		{
			#if DEBUG
			Debug.WriteLine(Message);
			#endif
		}
		public void WriteToLogFile(LogFile lf)
		{
			lf.Log(Message);
		}

		#endregion Public Methods

		#region Protected Methods

		#endregion Protected Methods

		#region Private Methods

		/// <summary>
		/// init all local vars to default values - should be called by all constructors
		/// </summary>
		private void CommonInit()
		{
			try
			{
				Message = string.Empty;
			}
			catch (System.Exception x) { Debug.WriteLine(x.Message); }
		}//end of CommonInit

		#endregion

		#endregion Methods

	}//end of ErrorMessage
}
