// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="PackagedProductModel.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products
{
    /// <summary>
    /// Class PackagedProductModel.
    /// </summary>
    public class PackagedProductModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string id { get; set; }
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public string productId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }//this is the market description for the product
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal price { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public decimal quantity { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>The details.</value>
        public PackagedProductDetailModel[] details { get; set; }
        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        public PackagedProductOptionModel[] options { get; set; }
    }
}
