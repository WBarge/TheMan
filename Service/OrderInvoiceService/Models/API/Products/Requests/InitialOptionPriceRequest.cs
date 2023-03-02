// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="InitialOptionPriceRequest.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products.Requests
{
    /// <summary>
    /// Class InitialOptionPriceRequest.
    /// </summary>
    public class InitialOptionPriceRequest
    {
        /// <summary>
        /// Gets or sets the option.
        /// </summary>
        /// <value>The option.</value>
        public ProductOptionModel Option { get; set; }
        /// <summary>
        /// Gets or sets the initial price.
        /// </summary>
        /// <value>The initial price.</value>
        public decimal InitialPrice { get; set; }
    }
}
