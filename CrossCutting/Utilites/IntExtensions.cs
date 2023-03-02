namespace Utilites
{
    public static class IntExtensions
    {

        /// <summary>
        /// Checks if the input int is 0.
        /// </summary>
        /// <param name="o">int to be checked.</param>
        /// <returns>true if the int is 0 or equals DefaultValues.DEFAULT_INT, else false.</returns>
        public static bool IsEmpty(this int i)
        {
            return i == 0 || i == DefaultValues.DefaultInt;
        }//Empty

        /// <summary>
        /// Checks if the input int is not 0.
        /// </summary>
        /// <param name="o">int to be checked.</param>
        /// <returns>true if the int is not empty, else false.</returns>
        public static bool IsNotEmpty(this int i)
        {
            return (!i.IsEmpty());
        }//Empty
    }
}
