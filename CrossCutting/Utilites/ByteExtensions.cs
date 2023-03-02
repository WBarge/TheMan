using System;

namespace Utilites
{
    public static class ByteExtensions
    {
        /// <summary>
        /// convert a byte to a bool
        /// </summary>
        /// <param name="b"></param>
        /// <returns>
        ///     true - b is a non zero value
        ///     false - default return value
        /// </returns>
        public static bool ToBool(this byte b)
        {
            bool returnValue = false;
            try
            {
                returnValue = (b != 0);
            }
            catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
            return (returnValue);
        }
    }
}
