using System;
using System.Collections.Generic;
using System.Text;
using OrderInvoice_BL.Application;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_BL_UnitTests.Application
{
    public class Constants
    {
        public const string CONFIGURATION_TEST_VALUE = "Some String";
    }
    

    internal static class DataCreator
    {

        public static IApplicationConfiguration CreateDataObject()
        {
            IApplicationConfiguration result = new ApplicationConfigurationTestObjcet();
            result.Objid = 1;
            result.Type = ApplicationConfigurationType.None.ToString();
            result.Configuration = Constants.CONFIGURATION_TEST_VALUE;
            return result;
        }
    }

    internal class ApplicationConfigurationTestObjcet : IApplicationConfiguration
    {
        public int Objid { get; set; }
        public string Type { get; set; }
        public string Configuration { get; set; }
    }
}
