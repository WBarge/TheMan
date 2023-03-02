namespace Utilites
{
    public static class LongExtensions
    {

        /// <summary>
        /// Checks if the input long is 0.
        /// </summary>
        /// <param name="o">long to be checked.</param>
        /// <returns>true if the long is 0 or equals DefaultValues.DEFAULT_LONG, else false.</returns>
        public static bool IsEmpty(this long l)
        {
            return l == 0L || l == DefaultValues.DefaultLong;
        }//Empty

        /// <summary>
        /// Checks if the input long is not 0.
        /// </summary>
        /// <param name="o">long to be checked.</param>
        /// <returns>true if the long is not empty, else false.</returns>
        public static bool IsNotEmpty(this long l)
        {
            return (!l.IsEmpty());
        }//Empty
    }
}
