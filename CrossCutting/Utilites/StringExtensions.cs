using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Utilites
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert the string to an enum
        /// </summary>
        /// <param name="str">the string to conver</param>
        /// <param name="defaultValue">the default value to set the enum to if the string can not be converted</param>
        /// <returns>
        ///     the converted value or the default value
        /// </returns>
        public static Enum ToEnum(this string str, Enum defaultValue)
        {
            Enum returnValue = defaultValue;
            int val = DefaultValues.DefaultInt;

            try
            {
                if (str.IsNotEmpty())
                {
                    if (Enum.IsDefined(defaultValue.GetType(), str) == false)
                    {
                        val = str.ToInt();
                        if (val != DefaultValues.DefaultInt && Enum.IsDefined(defaultValue.GetType(), val))
                        {
                            returnValue = (Enum)Enum.Parse(defaultValue.GetType(), str, false);
                        }
                    }
                    else
                    {
                        returnValue = (Enum)Enum.Parse(defaultValue.GetType(), str, true);
                    }
                }
            }
            catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
            return returnValue;
        }

        /// <summary>
        /// To the date time.
        /// </summary>
        /// <param name="str">The date as a string.</param>
        /// <param name="defaultvalue">The defaultvalue.</param>
        /// <returns>
        ///     The converted value.  If convertion fails the defaultValue will be returned
        /// </returns>
        public static DateTime ToDateTime(this string str, DateTime defaultvalue)
        {
            DateTime returnValue = defaultvalue;
            DateTime result = returnValue;
            if (DateTime.TryParse(str,out result))
            {
                returnValue = result;
            }
            return (returnValue);
        }

        /// <summary>
        /// Checks if the input string is null or empty.
        /// </summary>
        /// <param name="o">string to be checked.</param>
        /// <returns>true if the string is null or length == 0 or is equal string.empty, else false.</returns>
        public static bool IsEmpty(this string s)
        {
            return ((object)s).IsEmpty() || s.Length == 0 || s == string.Empty;
        }//Empty
        
        /// <summary>
        /// Checks if the input string is not empty.
        /// </summary>
        /// <param name="o">string to be checked.</param>
        /// <returns>true if the string is not empty, else false.</returns>
        public static bool IsNotEmpty(this string s)
        {
            return (!s.IsEmpty());
        }//NotEmpty

        /// <summary>
        /// Method to check for all decimal digits in a string
        /// </summary>
        /// <param name="number">the string to check</param>
        /// <returns>
        ///		true - the string is all numbers
        ///		false - the string is not all numbers
        /// </returns>
        public static bool IsNumeric(this string number)
        {
            bool returnValue = true;
            double result;
            NumberFormatInfo format;

            try
            {
                format = new NumberFormatInfo();
                returnValue = double.TryParse(number, NumberStyles.Number, format, out result);
            }
            catch (Exception) { returnValue = false; }
            return returnValue;
        }//end of IsNumeric

        /// <summary>
        /// Method that verifies the email format is correct
        /// </summary>
        /// <param name="email">email address to check</param>
        /// <returns>
        ///     true - the email is in a valid format
        ///     false - the email is not a valid email format
        /// </returns>
        public static bool IsValidEmail(this string email)
        {
            bool returnValue = false;
            string regexLocalPart1 = @"(([-!$&*=^`|~#%'+/?_`{}\w]+)(\.([-!$&*=^`|~#%'+/?_`{}\w])+)*)";
            string regexLocalPart2 = @"(""([^""\r]|\\[""\r\\])+"")";
            string regexDomain = @"@([\w]+[-.])*[\w]+[.]([a-zA-Z]{2,9})";
            string regex = string.Empty;
            string trimmedEmail = string.Empty;
            Regex reg = null;
            try
            {
                trimmedEmail = email.Trim();
                regex = string.Format(@"^({0}|{1}){2}$", regexLocalPart1, regexLocalPart2, regexDomain);
                reg = new Regex(regex, RegexOptions.None);
                returnValue = reg.Match(trimmedEmail).Success;
            }
            catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
            return returnValue;
        }//IsValidEmail

        /// <summary>
        /// Method to see if the email address is not in the correct format
        /// </summary>
        /// <param name="email">email address to check</param>
        /// <returns>
        ///     true - the email is not a valid email format
        ///     false - the email is in a valid format
        ///     </returns>
        public static bool IsNotValidEmail(this string email)
        {
            return (!email.IsValidEmail());
        }

        public static bool In(this string stringToFind,IEnumerable<string> listToSearch)
        {
            bool returnValue = false;
            foreach (string tempStr in listToSearch)
            {
                if (tempStr == stringToFind)
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }
    }
}