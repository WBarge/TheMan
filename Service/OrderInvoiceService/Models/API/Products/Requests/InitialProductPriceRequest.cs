// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="InitialProductPriceRequest.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products.Requests
{
    /// <summary>
    /// Class InitialProductPriceRequest.
    /// </summary>
    public class InitialProductPriceRequest
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public ProductModel Product { get; set; }
        /// <summary>
        /// Gets or sets the initial price.
        /// </summary>
        /// <value>The initial price.</value>
        public decimal InitialPrice { get; set; }
    }
}