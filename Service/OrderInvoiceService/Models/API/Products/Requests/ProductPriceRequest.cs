// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ProductPriceRequest.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products.Requests
{
    /// <summary>
    /// Class ProductPriceRequest.
    /// </summary>
    public class ProductPriceRequest
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public ProductModel Product { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public PriceModel Price { get; set; }
    }
}
