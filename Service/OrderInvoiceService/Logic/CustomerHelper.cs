// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="CustomerHelper.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using OrderInvoiceService.Models.API;

namespace OrderInvoiceService.Logic
{
    /// <summary>
    /// Class CustomerHelper - helper methods for managing customers
    /// </summary>
    public class CustomerHelper
    {
        /// <summary>
        /// Gets the next customer number.
        /// </summary>
        /// <param name="cm">The cm.</param>
        /// <returns>System.Int32.</returns>
        public static int GetNextCustomerNumber(ConfigurationManager cm)
        {
            SystemConfigurationModel scm = cm.GetConfiguration();

            if (scm.NextCustomerNumber < 1)
            {//defensive code - just incase the next number was set below 1 - should not happen
                scm.NextCustomerNumber = 0;
            }
            scm.NextCustomerNumber++;
            cm.SetConfiguration(scm);
            return scm.NextCustomerNumber;
        }
    }
}
