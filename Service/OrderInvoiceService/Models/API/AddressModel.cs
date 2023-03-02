// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="AddressModel.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API
{
    /// <summary>
    /// Class AddressModel.
    /// </summary>
    public class AddressModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>The address1.</value>
        public string Address1 { get; set; }
        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>The address2.</value>
        public string Address2 { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state value.
        /// </summary>
        /// <value>The state value.</value>
        public DropDownItemValue StateValue { get; set; }
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public string Zip { get; set; }
    }
}
