using System;

namespace Utilites
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Convert a bool to a byte
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns>
        ///     0 - default return value
        ///     1 - if b == true
        /// </returns>
        public static byte ToByte(this bool b)
        {
            byte returnValue = 0;
            try
            {
                if (b)
                {
                    returnValue = 1;
                }
            }
            catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
            return returnValue;
        }
    }
}
