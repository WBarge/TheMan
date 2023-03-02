// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ProductOptionsForProductRequest.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products.Requests
{
    /// <summary>
    /// Class ProductOptionsForProductRequest.
    /// </summary>
    public class ProductOptionsForProductRequest
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public ProductModel Product { get; set; }
        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        public ProductOptionModel[] Options { get; set; }
    }
}
