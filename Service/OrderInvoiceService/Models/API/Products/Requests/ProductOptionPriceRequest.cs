// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ProductOptionPriceRequest.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products.Requests
{
    /// <summary>
    /// Class ProductOptionPriceRequest.
    /// </summary>
    public class ProductOptionPriceRequest
    {
        /// <summary>
        /// Gets or sets the option.
        /// </summary>
        /// <value>The option.</value>
        public ProductOptionModel Option { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public PriceModel Price { get; set; }
    }
}