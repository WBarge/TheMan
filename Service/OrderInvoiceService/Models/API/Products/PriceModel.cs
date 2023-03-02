// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="PriceModel.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products
{
    /// <summary>
    /// Class PriceModel.
    /// </summary>
    public class PriceModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the start date time string.
        /// </summary>
        /// <value>The start date time string.</value>
        public string StartDateTimeString { get; set; }
        /// <summary>
        /// Gets or sets the end date time string.
        /// </summary>
        /// <value>The end date time string.</value>
        public string EndDateTimeString { get; set; }
        /// <summary>
        /// Gets or sets the flat price.
        /// </summary>
        /// <value>The flat price.</value>
        public decimal FlatPrice { get; set; }
        /// <summary>
        /// Gets or sets the formula price.
        /// </summary>
        /// <value>The formula price.</value>
        public string FormulaPrice { get; set; }
        /// <summary>
        /// Gets or sets the formula variables.
        /// </summary>
        /// <value>The formula variables.</value>
        public string[] FormulaVariables { get; set; }
    }
}
