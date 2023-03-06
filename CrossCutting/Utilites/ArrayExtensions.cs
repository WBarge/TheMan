using System;

namespace Utilites
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Checks if the input Array is empty.
        /// </summary>
        /// <param name="obj">array to be checked.</param>
        /// <returns>true if the obj is null or obj.count == 0 false, else false.</returns>
        public static bool IsEmpty(this Array obj)
        {
            return ((object)obj).IsEmpty() || obj.Length == 0;
        }//Empty

        /// <summary>
        /// Checks if the input Array is not empty.
        /// </summary>
        /// <returns>true if the Array is not empty.</returns>
        public static bool IsNotEmpty(this Array obj)
        {
            return (!obj.IsEmpty());
        }//Empty
    }
}
