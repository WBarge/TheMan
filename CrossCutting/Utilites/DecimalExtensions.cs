using System;

namespace Utilites
{
    public static class DecimalExtensions
    {

        /// <summary>
        /// Checks if the input decimal is 0.
        /// </summary>
        /// <param name="o">decimal to be checked.</param>
        /// <returns>true if the decimal is 0 or equals DefaultValues.DEFAULT_DECIMAL, else false.</returns>
        public static bool IsEmpty(this decimal d)
        {
            return d == 0.0M || d == DefaultValues.DefaultDecimal;
        }//Empty

        /// <summary>
        /// Checks if the input decimal is not 0.
        /// </summary>
        /// <param name="o">decimal to be checked.</param>
        /// <returns>true if the decimal is not empty, else false.</returns>
        public static bool IsNotEmpty(this decimal d)
        {
            return (!d.IsEmpty());
        }//Empty

        /// <summary>
        /// Converts a nullable decimal to a decimal
        /// </summary>
        /// <param name="d">the nullable decimal</param>
        /// <returns>
        /// If the nullable decimal is null then decimal.Zero else the value passed in
        /// </returns>
        public static decimal ToDecimal(this decimal? d)
        {
            decimal returnValue = decimal.Zero;
            try
            {
                if (d.HasValue)
                {
                    returnValue = d.Value;
                }
            }
            catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
            return (returnValue);
        }

        /// <summary>
        /// Determines if the float value is less than or equal to the float parameter according to the defined precision.
        /// </summary>
        /// <param name="dec1">The dec1.</param>
        /// <param name="dec2">The dec2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool LessThan(this decimal dec1, decimal dec2, int precision)
        {
            return (Math.Round(dec1 - dec2, precision) < 0);
        }

        /// <summary>
        /// Determines if the float value is less than or equal to the float parameter according to the defined precision.
        /// </summary>
        /// <param name="dec1">The dec1.</param>
        /// <param name="dec2">The dec2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool LessThanOrEqualTo(this decimal dec1, decimal dec2, int precision)
        {
            return (Math.Round(dec1 - dec2, precision) <= 0);
        }

        /// <summary>
        /// Determines if the float value is greater than (>) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="dec1">The dec1.</param>
        /// <param name="dec2">The dec2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool GreaterThan(this decimal dec1, decimal dec2, int precision)
        {
            return (Math.Round(dec1 - dec2, precision) > 0);
        }

        /// <summary>
        /// Determines if the float value is greater than or equal to (>=) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="dec1">The dec1.</param>
        /// <param name="dec2">The dec2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool GreaterThanOrEqualTo(this decimal dec1, decimal dec2, int precision)
        {
            return (Math.Round(dec1 - dec2, precision) >= 0);
        }

        /// <summary>
        /// Determines if the float value is equal to (==) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="dec1">The dec1.</param>
        /// <param name="dec2">The dec2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool AlmostEquals(this decimal dec1, decimal dec2, int precision)
        {
            return (Math.Round(dec1 - dec2, precision) == 0);
        }
    }
}
