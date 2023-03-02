// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="SystemConfigurationModel.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API
{
    /// <summary>
    /// Class SystemConfigurationModel.
    /// </summary>
    public class SystemConfigurationModel
    {
        /// <summary>
        /// Gets or sets the selected banner file.
        /// </summary>
        /// <value>The selected banner file.</value>
        public DropDownItemValue SelectedBannerFile { get; set; }
        /// <summary>
        /// Gets or sets the selected footer file.
        /// </summary>
        /// <value>The selected footer file.</value>
        public DropDownItemValue SelectedFooterFile { get; set; }
        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public string BackgroundColor { get; set; }
        /// <summary>
        /// Gets or sets the next customer number.
        /// </summary>
        /// <value>The next customer number.</value>
        public int NextCustomerNumber { get; set; }
    }
}
