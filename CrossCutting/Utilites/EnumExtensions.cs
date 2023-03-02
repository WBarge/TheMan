using System;

namespace Utilites
{
	public static class EnumExtensions
	{
		/// <summary>
		/// This will convert the enum to an integer value
		/// </summary>
		/// <param name="theEnum"></param>
		/// <returns></returns>
		public static int ToInt(this Enum theEnum)
		{
			int returnValue = int.MinValue;
			try
			{
				returnValue = ((int)(theEnum as object));
			}
			catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
			return (returnValue);
		}

		/// <summary>
		/// This will convert the enum to its integer value and return the integer value as a string
		/// </summary>
		/// <param name="theEnum"></param>
		/// <returns></returns>
		public static string ToIntString(this Enum theEnum)
		{
			int returnValue = int.MinValue;
			try
			{
				returnValue = theEnum.ToInt();
			}
			catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
			return (returnValue.ToString());
		}

		/// <summary>
		/// This will convert the enum to a string with a space before each capital letter in the enum
		/// </summary>
		/// <param name="theEnum"></param>
		/// <returns></returns>
		public static string ToSpacedString(this Enum theEnum)
		{
			string returnValue = string.Empty;
			char[] charList = null;
			try
			{
				charList = theEnum.ToString().ToCharArray();
				for (int offSet = 0; offSet < charList.Length; offSet++)
				{
					if (offSet > 0 && charList[offSet] >= 'A' && charList[offSet] <= 'Z')
					{
						returnValue += " ";
					}
					returnValue += charList[offSet];
				}
				returnValue = returnValue.Trim();
			}
			catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
			return (returnValue);
		}
	}
}