using System.Collections;

namespace Utilites
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Checks if the input ICollection is empty.
        /// </summary>
        /// <param name="obj">collection to be checked.</param>
        /// <returns>true if the obj is null or obj.count == 0, else false.</returns>
        public static bool IsEmpty(this ICollection obj)
        {
            return ((object)obj).IsEmpty() || obj.Count == 0;
        }//Empty

        /// <summary>
        /// Checks if the input ICollection is not empty.
        /// </summary>
        /// <param name="o">ICollection to be checked.</param>
        /// <returns>true if the ICollection is not empty.</returns>
        public static bool IsNotEmpty(this ICollection obj)
        {
            return (!obj.IsEmpty());
        }//Empty
    }
}
