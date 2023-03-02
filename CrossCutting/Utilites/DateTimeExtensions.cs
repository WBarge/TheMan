using System;

namespace Utilites
{
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Checks if the input datetime is empty.
        /// </summary>
        /// <param name="obj">datetime to be checked.</param>
        /// <returns>true if the obj is null or == DateTime.MinValue or == DateTime.MaxValue, else false.</returns>
        public static bool IsEmpty(this DateTime obj)
        {
            return ((object)obj).IsEmpty() || obj == DateTime.MinValue || obj == DateTime.MaxValue;
        }//Empty

        /// <summary>
        /// Checks if the input System.DateTime is not empty.
        /// </summary>
        /// <param name="o">System.DateTime to be checked.</param>
        /// <returns>true if the System.DateTime is not empty.</returns>
        public static bool IsNotEmpty(this DateTime obj)
        {
            return (!obj.IsEmpty());
        }

        /// <summary>
        /// Converts nullable datetime to a datetime
        /// </summary>
        /// <param name="dt">the nullable datetime</param>
        /// <param name="defaultTime">The default datetime to use if dt is null</param>
        /// <returns>
        /// If nullable datetime is null then DateTime.Min else the value passed in
        /// </returns>
        public static DateTime ToDateTime(this DateTime? dt,DateTime defaultTime)
        {
            DateTime returnValue = defaultTime;
            try
            {
                if (dt.HasValue)
                {
                    returnValue = dt.Value;
                }
            }
            catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
            return (returnValue);
        }

        /// <summary>
        /// To the date time.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateTime? dt)
        {
            return (dt.ToDateTime(DateTime.MinValue));
        }
    }
}
