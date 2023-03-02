namespace Utilites
{
    public static class CharExtensions
    {
        /// <summary>
        /// return weather or not a char is a number
        /// </summary>
        /// <param name="num">the character to check</param>
        /// <returns>
        ///		true - the character is a number
        ///		false - the character is not a number
        /// </returns>
        public static bool IsNumeric(this char num)
        {
            switch (num)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;
                default:
                    return false;
            }
        }//end of IsNumeric
    }
}
