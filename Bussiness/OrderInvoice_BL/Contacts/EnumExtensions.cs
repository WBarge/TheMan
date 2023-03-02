using Utilites;

namespace OrderInvoice_BL.Contacts
{
    /// <summary>
    /// extensions to help convert from enum type to another
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///  convert from Country_Abbreviation to Country_Name
        /// </summary>
        /// <param name="theEnum"></param>
        /// <returns></returns>
        public static CountryName ToCountry_Name(this CountryAbbreviation theEnum)
        {
            CountryName returnValue = CountryName.None;
                returnValue = (CountryName)theEnum.ToInt();
            return (returnValue);
        }

        /// <summary>
        ///  convert from Country_Name to Country_Abbreviation
        /// </summary>
        /// <param name="theEnum"></param>
        /// <returns></returns>
        public static CountryAbbreviation ToCountry_Abbreviation(this CountryName theEnum)
        {
            CountryAbbreviation returnValue = CountryAbbreviation.None;
                returnValue = (CountryAbbreviation)theEnum.ToInt();
            return (returnValue);
        }

        /// <summary>
        ///  convert from US_State_Abbreviation to US_State_Name
        /// </summary>
        /// <param name="theEnum"></param>
        /// <returns></returns>
        public static UsStateName ToState_Name(this UsStateAbbreviation theEnum)
        {
            UsStateName returnValue = UsStateName.None;
                returnValue = (UsStateName)theEnum.ToInt();
            return (returnValue);
        }

        /// <summary>
        ///  convert from US_State_Name to US_State_Abbreviation
        /// </summary>
        /// <param name="theEnum"></param>
        /// <returns></returns>
        public static UsStateAbbreviation ToState_Abbreviation(this UsStateName theEnum)
        {
            UsStateAbbreviation returnValue = UsStateAbbreviation.None;
                returnValue = (UsStateAbbreviation)theEnum.ToInt();
            return (returnValue);
        }
    }
}