using System;

namespace Utilites
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Checks is the input Guid is empty
        /// </summary>
        /// <param name="g">guid to be checked</param>
        /// <returns>true if the g is null or == Guid.Empty</returns>
        public static bool IsEmpty(this Guid g)
        {
            return ((object)g).IsEmpty() || g == Guid.Empty;
        }

        /// <summary>
        /// Checks if the input System.DateTime is not empty.
        /// </summary>
        /// <param name="o">Guid to be checked.</param>
        /// <returns>true if the Guid is not empty.</returns>
        public static bool IsNotEmpty(this Guid obj)
        {
            return (!obj.IsEmpty());
        }
    }
}
